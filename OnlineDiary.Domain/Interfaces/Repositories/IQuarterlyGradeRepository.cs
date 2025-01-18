using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IQuarterlyGradeRepository : IRepository<QuarterlyGrade>
{
    Task<IEnumerable<QuarterlyGrade>> GetByStudentIdTermIdAsync(Guid studentId, Guid termId);
    Task<IEnumerable<QuarterlyGrade>> GetByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId);
}
