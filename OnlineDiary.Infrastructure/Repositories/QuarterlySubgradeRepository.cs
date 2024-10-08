using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class QuarterlySubgradeRepository : BaseRepository<QuarterlySubgrade>, IQuarterlySubgradeRepository
    {
        public QuarterlySubgradeRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<QuarterlySubgrade>> GetByQuarterlyGradeIdAsync(Guid quarterlyGradeId)
        {
            return await _dbSet
                .Where(q => q.QuarterlyGradeId == quarterlyGradeId)
                .ToListAsync();
        }
    }
}
