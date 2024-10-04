using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
{
    public DirectorRepository(SchoolDbContext context) : base(context) { }

    public async Task<Director> GetDirectorByIdAsync(Guid directorId)
    {
        return await base.GetByIdAsync(directorId);
    }

    public async Task<Director> GetDirectorBySchoolIdAsync(Guid schoolId)
    {
        return await _context.Directors.FirstOrDefaultAsync(d => d.SchoolId == schoolId);
    }

    public async Task<Director> GetDirectorByUserIdAsync(Guid userId)
    {
        return await _context.Directors.FirstOrDefaultAsync(d => d.UserId == userId);
    }
}
