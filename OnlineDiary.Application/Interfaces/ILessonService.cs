using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ILessonService
{
    Task<Lesson> GetLessonByIdAsync(Guid lessonId);
    Task<IEnumerable<Lesson>> GetLessonsByTeacherForWeekAsync(Guid teacherId, DateTime date);
    Task<IEnumerable<Lesson>> GetLessonsByClassForWeekAsync(Guid classId, DateTime date);
    Task<IEnumerable<Lesson>> GetLessonsByClassSubjectAndTermAsync(Guid classId, Guid subjectId, Guid termId);

    Task CreateLessonsByScheduleAsync(Schedule schedule);
    Task UpdateLessonAsync(Guid lessonId, Lesson lesson);

    Task DeleteLessonAsync(Guid lessonId);
}
