using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IQuarterlyGradeService
{
    Task<QuarterlyGrade> GetQuarterlyGradeByIdAsync(Guid quarterlyGradeId);

    Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByStudentIdTermIdAsync(Guid studentId, Guid termId);
    Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId);

    Task CreateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade);

    Task UpdateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade);

    Task DeleteQuarterlyGradeAsync(Guid quarterlyGradeId);
}
