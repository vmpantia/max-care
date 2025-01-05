using MC.Infrastructure.Databases.Contexts;
using MC.Infrastructure.Databases.Contracts;
using MC.Infrastructure.Models.Entities;
using MC.Shared.Models.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace MC.Infrastructure.Databases.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(MaxCareDbContext maxCareDbContext) : base(maxCareDbContext) { }

        public async Task<IEnumerable<Contact>> GetMemberContactsAsync(Guid memberId, CancellationToken cancellationToken = default) =>
            await GetByExpression(contact => contact.ResourceId == memberId &&
                                             contact.ResourceType == ResourceType.Member)
                .ToListAsync(cancellationToken);
    }
}
