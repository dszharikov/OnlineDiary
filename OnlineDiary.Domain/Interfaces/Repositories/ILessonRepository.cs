using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ILessonRepository : IRepository<Lesson>
{
    Task<IEnumerable<Lesson>> GetByScheduleIdAsync(Guid scheduleId);

    Task<IEnumerable<Lesson>> GetByDateAsync(DateTime date);

}
