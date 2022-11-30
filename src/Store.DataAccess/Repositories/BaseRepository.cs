using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Base;
using Store.Core.Exceptions;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories.Contracts;
using System.Linq.Expressions;

namespace Store.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            // Soft delete, setting active as false
            entity.Active = false;
            var removedEntity = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<bool> DeleteManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            _dbSet.Where(predicate).ToList().ForEach(x => x.Active = false);
            var elementsAffected = await _context.SaveChangesAsync();

            return elementsAffected > 0;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(entity => entity.Active == true).Where(predicate).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetPaginatedAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            return await _dbSet.Where(entity => entity.Active == true).Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _dbSet.Where(entity => entity.Active == true).Where(predicate).FirstOrDefaultAsync();

            if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
