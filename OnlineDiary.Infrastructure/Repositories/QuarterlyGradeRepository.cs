using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class QuarterlyGradeRepository : BaseRepository<QuarterlyGrade>, IQuarterlyGradeRepository
{
    public QuarterlyGradeRepository(SchoolDbContext context) : base(context) { }

    public override IQueryable<QuarterlyGrade> GetAllAsync()
    {
        return _dbSet
            .Include(q => q.Student)
            .Include(q => q.ClassSubject).ThenInclude(q => q.Class);
    }

    override public async Task<QuarterlyGrade> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(q => q.Student)
            .Include(q => q.ClassSubject).ThenInclude(q => q.Class)
            .FirstOrDefaultAsync(q => q.QuarterlyGradeId == id);
    }

    public async Task<IEnumerable<QuarterlyGrade>> GetByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId)
    {
        return await GetAllAsync()
            .Where(q => q.ClassSubjectId == classSubjectId && q.TermId == termId)
            .ToListAsync();
    }

    public async Task<IEnumerable<QuarterlyGrade>> GetByStudentIdTermIdAsync(Guid studentId, Guid termId)
    {
        return await GetAllAsync()
            .Where(q => q.StudentId == studentId && q.TermId == termId)
            .ToListAsync();
    }
}
