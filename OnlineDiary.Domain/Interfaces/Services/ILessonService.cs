using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface ILessonService
{
    Task<Lesson> GetLessonByIdAsync(Guid lessonId);

    Task<IEnumerable<Lesson>> GetLessonsByScheduleIdAsync(Guid scheduleId);

    Task CreateLessonAsync(Lesson lesson);

    Task UpdateLessonAsync(Lesson lesson);

    Task DeleteLessonAsync(Guid lessonId);
}
