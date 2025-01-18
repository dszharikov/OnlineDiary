using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ILessonRepository : IRepository<Lesson>
{
    Task AddRangeAsync(IEnumerable<Lesson> lessons);
    Task<IEnumerable<Lesson>> GetByClassForWeekAsync(Guid classId, DateTime date);
    Task<IEnumerable<Lesson>> GetByClassSubjectAndTermAsync(Guid classId, Guid subjectId, Guid termId);
    Task<IQueryable<Lesson>> GetBySchedule(Guid scheduleId);
    Task<IEnumerable<Lesson>> GetByTeacherForWeekAsync(Guid teacherId, DateTime date);
}
