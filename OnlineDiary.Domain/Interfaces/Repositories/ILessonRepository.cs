using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface ILessonRepository : IRepository<Lesson>
{
    Task<Lesson> GetByScheduleAndDateAsync(Guid scheduleId, DateTime date);
    Task<IEnumerable<Lesson>> GetByDateAsync(DateTime date);

    Task<IEnumerable<Lesson>> GetByDateRangeAndTeacherIdAsync(DateTime startDate, DateTime endDate, Guid teacherId);

    Task<IEnumerable<Lesson>> GetByDateRangeAndStudentIdAsync(DateTime startDate, DateTime endDate, Guid classId);

    Task<IEnumerable<Lesson>> GetByClassSubjectIdAndTermIdAsync(Guid classSubjectId, Guid termId);

}
