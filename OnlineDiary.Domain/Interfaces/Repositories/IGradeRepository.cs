using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IGradeRepository : IRepository<Grade>
{
    Task<IEnumerable<Grade>> GetGradesForStudentByTermAsync(Guid studentId, Guid termId);
    Task<IEnumerable<Grade>> GetGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId);
}