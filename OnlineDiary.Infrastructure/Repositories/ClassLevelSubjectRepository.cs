using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ClassLevelSubjectRepository : BaseRepository<ClassLevelSubject>, IClassLevelSubjectRepository
    {
        public ClassLevelSubjectRepository(SchoolDbContext context) : base(context) { }

        public async Task<ClassLevelSubject> GetByClassLevelAndSubjectAsync(int classLevel, Guid subjectId)
        {
            return await _dbSet
                .Include(cls => cls.Subject)
                .FirstOrDefaultAsync(cls => cls.ClassLevel == classLevel && cls.SubjectId == subjectId);
        }

        public async Task<IEnumerable<ClassLevelSubject>> GetByClassLevelAsync(int classLevel)
        {
            return await _dbSet
                .Where(cls => cls.ClassLevel == classLevel)
                .Include(cls => cls.Subject)
                .ToListAsync();
        }

        public override async Task<ClassLevelSubject> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(cls => cls.Subject)
                .FirstOrDefaultAsync(cls => cls.ClassLevelSubjectId == id);
        }

        public override async Task<IEnumerable<ClassLevelSubject>> GetAllAsync()
        {
            return await _dbSet
                .Include(cls => cls.Subject)
                .ToListAsync();
        }
    }
}
