using System.Linq.Expressions;
using Store.Core.Entities.Base;

namespace Store.DataAccess.Repositories.Contracts;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

    Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

    Task<ICollection<TEntity>> GetPaginatedAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize);

    Task<bool> DeleteManyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);

    Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);
}