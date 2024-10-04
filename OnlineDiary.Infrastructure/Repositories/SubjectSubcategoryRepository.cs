using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class SubjectSubcategoryRepository : BaseRepository<SubjectSubcategory>, ISubjectSubcategoryRepository
    {
        public SubjectSubcategoryRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<SubjectSubcategory>> GetBySubjectIdAsync(Guid subjectId)
        {
            return await _context.SubjectSubcategories
                .Where(s => s.SubjectId == subjectId)
                .ToListAsync();
        }
    }
}
