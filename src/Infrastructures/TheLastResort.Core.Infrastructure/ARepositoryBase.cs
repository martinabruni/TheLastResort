using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheLastResort.Core.Domain.Interfaces;
using TheLastResort.Core.Infrastructure.Models;

namespace TheLastResort.Core.Infrastructure
{
    public abstract class ARepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly SqldbThelastresortCoreDevContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected ARepositoryBase(SqldbThelastresortCoreDevContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity?> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            if (!(await ExistsAsync(e => e.Id!.Equals(entity.Id))))
                return null;
            var dbEntity = await GetAsync(entity.Id);
            _dbContext.Entry(dbEntity!).State = EntityState.Detached;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return dbEntity;
        }

        public virtual async Task<TEntity?> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return null;
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetAsync(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            if(includes is null)
                return await _dbSet.FindAsync(id);
            foreach (var include in includes)
            {
                _dbSet.Include(include);
            }
            return await _dbSet.FirstOrDefaultAsync(e => e.Id!.Equals(id));
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter is null)
                return await _dbSet.ToListAsync();
            return await _dbSet.Where(filter).ToListAsync();
        }
    }
}
