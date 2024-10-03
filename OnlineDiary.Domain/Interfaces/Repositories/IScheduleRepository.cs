using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IScheduleRepository : IRepository<Schedule>
{
    Task<IEnumerable<Schedule>> GetByClassIdAsync(Guid classId);

    Task<IEnumerable<Schedule>> GetByTeacherIdAsync(Guid teacherId);

    Task<IEnumerable<Schedule>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek);

    // Дополнительные методы по необходимости
}
