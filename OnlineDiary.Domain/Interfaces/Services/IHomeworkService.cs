using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IHomeworkService
{
    Task<Homework> GetHomeworkByIdAsync(Guid homeworkId);

    Task<IEnumerable<Homework>> GetHomeworksByLessonIdAsync(Guid lessonId);

    Task CreateHomeworkAsync(Homework homework);

    Task UpdateHomeworkAsync(Homework homework);

    Task DeleteHomeworkAsync(Guid homeworkId);
}
