using MC.Infrastructure.Models.Interfaces;
using MC.Shared.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MC.Infrastructure.Databases.Interceptors
{
    public class MaintainableEntitiesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            // Get database context on the event data
            var dbContext = eventData.Context;

            // Check if the database context is NULL
            if (dbContext is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            // Get all the entries
            var entries = dbContext.ChangeTracker.Entries<IMaintainableEntity>();

            foreach (var entry in entries)
            {
                // Update maintainable properties based on the entry state
                if (entry.State == EntityState.Added && 
                    entry.Entity is ICreatableEntity creatable)
                {
                    creatable.CreatedAtUtc = DateTime.UtcNow;
                    creatable.CreatedBy = "System";
                }
                else if (entry.State == EntityState.Modified && 
                         entry.Property(prop => prop.Status).CurrentValue != Status.Deleted &&
                         entry.Entity is IEditableEntity editable)
                {
                    editable.EditedAtUtc = DateTime.UtcNow;
                    editable.EditedBy = "System";
                }
                else if (entry.State == EntityState.Modified &&
                         entry.Entity is IDeletableEntity delitable)
                {
                    delitable.DeletedAtUtc = DateTime.UtcNow;
                    delitable.DeletedBy = "System";
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
