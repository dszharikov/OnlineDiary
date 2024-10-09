using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IScheduleService
{
    Task<Schedule> GetScheduleByIdAsync(Guid scheduleId);

    Task<IEnumerable<Schedule>> GetSchedulesByTermClassAsync(Guid termId, Guid classId);

    Task<IEnumerable<Schedule>> GetSchedulesByTermTeacherAsync(Guid termId, Guid teacherId);

    Task CreateScheduleAsync(Schedule schedule);

    Task UpdateScheduleAsync(Guid scheduleId, Schedule schedule);

    Task DeleteScheduleAsync(Guid scheduleId);
}
