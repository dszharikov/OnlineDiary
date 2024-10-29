using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Infrastructure.Data;
using System.Linq.Expressions;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
