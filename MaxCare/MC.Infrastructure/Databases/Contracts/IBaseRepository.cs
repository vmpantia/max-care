using System.Linq.Expressions;

namespace MC.Infrastructure.Databases.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetOne(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
    }
}
