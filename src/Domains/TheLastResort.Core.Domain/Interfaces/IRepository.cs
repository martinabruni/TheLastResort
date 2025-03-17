using System.Linq.Expressions;

namespace TheLastResort.Core.Domain.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity?> AddAsync(TEntity entity);

        Task<TEntity?> UpdateAsync(TEntity entity);

        Task<TEntity?> DeleteAsync(TKey id);

        Task<TEntity?> GetAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}
