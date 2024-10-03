using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IQuarterlyGradeService
{
    Task<QuarterlyGrade> GetQuarterlyGradeByIdAsync(Guid quarterlyGradeId);

    Task<IEnumerable<QuarterlyGrade>> GetQuarterlyGradesByStudentIdAsync(Guid studentId);

    Task<QuarterlyGrade> GetQuarterlyGradeByStudentSubjectTermAsync(Guid studentId, Guid subjectId, Guid termId);

    Task CreateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade);

    Task UpdateQuarterlyGradeAsync(QuarterlyGrade quarterlyGrade);

    Task DeleteQuarterlyGradeAsync(Guid quarterlyGradeId);
}
