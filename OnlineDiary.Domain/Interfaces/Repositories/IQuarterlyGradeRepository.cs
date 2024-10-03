using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IQuarterlyGradeRepository : IRepository<QuarterlyGrade>
{
    Task<IEnumerable<QuarterlyGrade>> GetByStudentAsync(Guid studentId);
    Task<IEnumerable<QuarterlyGrade>> GetBySubjectAsync(Guid subjectId);
    Task<QuarterlyGrade> GetByStudentSubjectTermAsync(Guid studentId, Guid subjectId, Guid termId);
}
