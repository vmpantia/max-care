using MC.Infrastructure.Databases.Contexts;
using MC.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MC.Infrastructure.Databases.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly MaxCareDbContext _context;
        private readonly DbSet<TEntity> _table;

        public BaseRepository(MaxCareDbContext maxCareDbContext)
        {
            _context = maxCareDbContext;
            _table = maxCareDbContext.Set<TEntity>();

            ArgumentNullException.ThrowIfNull(_context);
            ArgumentNullException.ThrowIfNull(_table);
        }

        public IQueryable<TEntity> GetAll() => _table;

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate) => _table.Where(predicate);

        public TEntity? GetOne(Expression<Func<TEntity, bool>> predicate) => _table.FirstOrDefault(predicate);

        public async Task<TEntity> CreateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default)
        {
            var result = await _table.AddAsync(entity, cancellationToken);

            // Check if allow automatically save to database
            if(isAutoSave) await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default)
        {
            var result = _table.Update(entity);

            // Check if allow automatically save to database
            if (isAutoSave) await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default)
        {
            var result = _table.Remove(entity);

            // Check if allow automatically save to database
            if (isAutoSave) await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }

        public void Dispose() => _context.Dispose();
    }
}
