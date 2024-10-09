using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class QuarterlySubgradeRepository : BaseRepository<QuarterlySubgrade>, IQuarterlySubgradeRepository
    {
        public QuarterlySubgradeRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<QuarterlySubgrade>> GetByTermClassSubjectIdAsync
            (Guid termId, Guid classSubjectId)
        {
            return await _dbSet
                .Where(q => q.TermId == termId && q.ClassSubjectId == classSubjectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<QuarterlySubgrade>> GetByTermStudentClassSubjectAsync
            (Guid termId, Guid classSubjectId, Guid subcategoryId)
        {
            return await _dbSet
                .Where(q => q.TermId == termId && q.ClassSubjectId == classSubjectId && q.SubcategoryId == subcategoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<QuarterlySubgrade>> GetByTermStudentClassSubjectIdAsync
            (Guid termId, Guid studentId, Guid classSubjectId)
        {
            return await _dbSet
                .Where(q => q.TermId == termId && q.StudentId == studentId && q.ClassSubjectId == classSubjectId)
                .ToListAsync();
        }

        public Task<QuarterlySubgrade> GetByTermStudentSubcategoryAsync(Guid termId, Guid StudentId, Guid SubcategoryId)
        {
            return _dbSet
                .FirstOrDefaultAsync(
                    q => q.TermId == termId 
                    && q.StudentId == StudentId 
                    && q.SubcategoryId == SubcategoryId);
        }
    }
}
