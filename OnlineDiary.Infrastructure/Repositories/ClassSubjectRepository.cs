using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ClassSubjectRepository : BaseRepository<ClassSubject>, IClassSubjectRepository
    {
        public ClassSubjectRepository(SchoolDbContext context) : base(context) { }

        public async Task<ClassSubject> GetByClassAndSubjectAsync(Guid classId, Guid subjectId)
        {
            return await _context.ClassSubjects
                .FirstOrDefaultAsync(cs => cs.ClassId == classId && cs.SubjectId == subjectId);
        }

        public async Task<IEnumerable<ClassSubject>> GetByClassIdAsync(Guid classId)
        {
            return await _context.ClassSubjects
                .Where(cs => cs.ClassId == classId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClassSubject>> GetBySubjectIdAsync(Guid subjectId)
        {
            return await _context.ClassSubjects
                .Where(cs => cs.SubjectId == subjectId)
                .ToListAsync();
        }
    }
}
