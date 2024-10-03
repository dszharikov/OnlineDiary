using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IHomeworkRepository : IRepository<Homework>
{
    Task<IEnumerable<Homework>> GetByLessonIdAsync(Guid lessonId);
    Task<IEnumerable<Homework>> GetByDueDateAsync(DateTime dueDate);
}
