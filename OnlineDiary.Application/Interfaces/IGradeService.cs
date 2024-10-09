using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IGradeService
{
    Task<Grade> GetGradeByIdAsync(Guid gradeId);
    Task<IEnumerable<Grade>> GetAllGradesAsync();
    Task<IEnumerable<Grade>> GetGradesForStudentByTermIdAsync(Guid studentId, Guid termId);
    Task<IEnumerable<Grade>> GetGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId);
    Task CreateGradeAsync(Grade dto);
    Task UpdateGradeAsync(Guid gradeId, Grade dto);
    Task DeleteGradeAsync(Guid gradeId);
}
