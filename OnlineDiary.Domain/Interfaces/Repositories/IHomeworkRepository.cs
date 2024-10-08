using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IHomeworkRepository : IRepository<Homework>
{
    Task<Homework> GetByLessonIdAsync(Guid lessonId);
    Task<IEnumerable<Homework>> GetActualHomeworkByStudentIdAsync(Guid studentId);
}
