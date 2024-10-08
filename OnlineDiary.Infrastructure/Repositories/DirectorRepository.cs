using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
{
    public DirectorRepository(SchoolDbContext context) : base(context) { }

    public async Task<Director> GetDirectorBySchoolIdAsync(Guid schoolId)
    {
        return await _dbSet
            .Include(d => d.School)
            .FirstOrDefaultAsync(d => d.SchoolId == schoolId);
    }

    public override async Task<IEnumerable<Director>> GetAllAsync()
    {
        return await _dbSet
            .Include(d => d.School)
            .ToListAsync();
    }

    public override async Task<Director> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(d => d.School)
            .FirstOrDefaultAsync(d => d.UserId == id);
    }
}
