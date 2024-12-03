using System.Linq.Expressions;

namespace MC.Shared.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetOne(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, bool isAutoSave = true, CancellationToken cancellationToken = default);
    }
}
