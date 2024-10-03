using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IScheduleService
{
    Task<Schedule> GetScheduleByIdAsync(Guid scheduleId);

    Task<IEnumerable<Schedule>> GetSchedulesByClassIdAsync(Guid classId);

    Task<IEnumerable<Schedule>> GetSchedulesByTeacherIdAsync(Guid teacherId);

    Task CreateScheduleAsync(Schedule schedule);

    Task UpdateScheduleAsync(Schedule schedule);

    Task DeleteScheduleAsync(Guid scheduleId);
}
