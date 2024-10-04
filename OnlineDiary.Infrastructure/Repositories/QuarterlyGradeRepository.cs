using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class QuarterlyGradeRepository : BaseRepository<QuarterlyGrade>, IQuarterlyGradeRepository
    {
        public QuarterlyGradeRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<QuarterlyGrade>> GetByStudentAsync(Guid studentId)
        {
            return await _context.QuarterlyGrades
                .Where(q => q.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<QuarterlyGrade> GetByStudentSubjectTermAsync(Guid studentId, Guid subjectId, Guid termId)
        {
            return await _context.QuarterlyGrades
                .Where(q => q.StudentId == studentId && q.SubjectId == subjectId && q.TermId == termId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<QuarterlyGrade>> GetBySubjectAsync(Guid subjectId)
        {
            return await _context.QuarterlyGrades
                .Where(q => q.SubjectId == subjectId)
                .ToListAsync();
        }
    }
}
