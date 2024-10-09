using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ILessonService
{
    Task<Lesson> GetLessonByIdAsync(Guid lessonId);

    Task<IEnumerable<Lesson>> GetLessonsByDateAsync(DateTime date);

    Task<IEnumerable<Lesson>> GetLessonsByDateRangeAndTeacherIdAsync(DateTime startDate, DateTime endDate, Guid teacherId);

    Task<IEnumerable<Lesson>> GetLessonsByDateRangeAndStudentIdAsync(DateTime startDate, DateTime endDate, Guid classId);

    Task<IEnumerable<Lesson>> GetLessonsByClassSubjectIdAndTermIdAsync(Guid classSubjectId, Guid termId);

    Task CreateLessonAsync(Lesson lesson);

    Task UpdateLessonAsync(Guid lessonId, Lesson lesson);

    Task DeleteLessonAsync(Guid lessonId);
}
