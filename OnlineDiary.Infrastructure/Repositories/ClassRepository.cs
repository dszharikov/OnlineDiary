using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class ClassRepository : BaseRepository<Class>, IClassRepository
{
    public ClassRepository(SchoolDbContext context) : base(context) { }

    public override IQueryable<Class> GetAllAsync()
    {
        IQueryable<Class> result = _dbSet
            .OrderBy(c => c.ClassLevel)
            .Include(c => c.HomeroomTeacher);
        return result;
    }

    public override async Task<Class> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.HomeroomTeacher)
            .FirstOrDefaultAsync(c => c.ClassId == id);
    }

    public async Task<Class> GetByNameAsync(string className)
    {
        return await _dbSet
            .Include(c => c.HomeroomTeacher)
            .FirstOrDefaultAsync(c => c.Name == className);
    }
}
