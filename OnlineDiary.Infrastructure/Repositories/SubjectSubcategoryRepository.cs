using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class SubjectSubcategoryRepository : BaseRepository<SubjectSubcategory>, ISubjectSubcategoryRepository
    {
        public SubjectSubcategoryRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<SubjectSubcategory>> GetBySubjectIdAsync(Guid subjectId)
        {
            return await _dbSet
                .Where(s => s.SubjectId == subjectId)
                .Include(s => s.Subject)
                .ToListAsync();
        }

        public override async Task<SubjectSubcategory> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => s.SubcategoryId == id);
        }

        public override async Task<IEnumerable<SubjectSubcategory>> GetAllAsync()
        {
            return await _dbSet
                .Include(s => s.Subject)
                .ToListAsync();
        }
    }
}
