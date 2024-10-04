using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ClassLevelSubjectRepository : BaseRepository<ClassLevelSubject>, IClassLevelSubjectRepository
    {
        public ClassLevelSubjectRepository(SchoolDbContext context) : base(context) { }

        public async Task<ClassLevelSubject> GetByClassLevelAndSubjectAsync(int classLevel, Guid subjectId)
        {
            return await _context.ClassLevelSubjects
                .FirstOrDefaultAsync(cls => cls.ClassLevel == classLevel && cls.SubjectId == subjectId);
        }

        public async Task<IEnumerable<ClassLevelSubject>> GetByClassLevelIdAsync(int classLevel)
        {
            return await _context.ClassLevelSubjects
                .Where(cls => cls.ClassLevel == classLevel)
                .ToListAsync();
        }
    }
}
