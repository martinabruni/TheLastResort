using System.Linq.Expressions;

namespace TheLastResort.Core.Domain.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<bool> AddAsync(TEntity entity, params Expression<Func<>>);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TKey id);

        Task<bool> GetAsync(TKey id);

        Task<bool> GetAsync();

        Task<bool> ExistsAsync(TKey id);
    }
}
