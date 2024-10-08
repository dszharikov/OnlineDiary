using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class SchoolRepository : BaseRepository<School>, ISchoolRepository
{
    public SchoolRepository(SchoolDbContext context) : base(context) { }

    public async Task<School> GetCurrentSchoolAsync()
    {
        return await _dbSet
            .FirstOrDefaultAsync();
    }

    public async Task<School> GetSchoolByIdAsync(Guid schoolId)
    {
        return await base.GetByIdAsync(schoolId);
    }

    public async Task<School> GetSchoolWithDirectorAsync(Guid schoolId)
    {
        return await _dbSet
            .Include(s => s.Director)
            .FirstOrDefaultAsync(s => s.SchoolId == schoolId);
    }
}
