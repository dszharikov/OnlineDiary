using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IGradeService
{
    Task<Grade> GetGradeByIdAsync(Guid gradeId);

    Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(Guid studentId);

    Task<IEnumerable<Grade>> GetGradesByLessonIdAsync(Guid lessonId);

    Task CreateGradeAsync(Grade grade);

    Task UpdateGradeAsync(Grade grade);

    Task DeleteGradeAsync(Guid gradeId);
}
