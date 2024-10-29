using System.Linq.Expressions;

namespace OnlineDiary.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);

    Task<IQueryable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}