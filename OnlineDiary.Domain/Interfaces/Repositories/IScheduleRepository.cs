using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IScheduleRepository : IRepository<Schedule>
{
    Task<IEnumerable<Schedule>> GetByTermTeacherAsync(Guid termId, Guid teacherId);

    Task<IEnumerable<Schedule>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek);
    Task<IEnumerable<Schedule>> GetByTermClassAsync(Guid termId, Guid classId);
    Task<Schedule> GetByTermClassSubjectDayOfWeekTimeAsync(Guid termId, Guid classSubjectId, DayOfWeek dayOfWeek, TimeOnly time);
}
