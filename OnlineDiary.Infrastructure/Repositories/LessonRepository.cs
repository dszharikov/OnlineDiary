using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(SchoolDbContext context) : base(context) { }

    public Task AddRangeAsync(IEnumerable<Lesson> lessons)
    {
        _dbSet.AddRange(lessons);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Lesson>> GetByClassForWeekAsync(Guid classId, DateTime date)
    {
        var baseQuery = GetAllAsync();
        var startDate = new DateTime(DateOnly.FromDateTime(date.Date.AddDays(-(int)date.DayOfWeek + 1)), TimeOnly.MinValue);
        var endDate = new DateTime(DateOnly.FromDateTime(date.Date.AddDays(7)), TimeOnly.MaxValue);

        return await baseQuery
            .Where(l => l.ClassSubject.ClassId == classId 
                && l.Date >= startDate && l.Date <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Lesson>> GetByTeacherForWeekAsync(Guid teacherId, DateTime date)
    {
        var baseQuery = GetAllAsync();
        var startDate = new DateTime(DateOnly.FromDateTime(date.Date.AddDays(-(int)date.DayOfWeek + 1)), TimeOnly.MinValue);
        var endDate = new DateTime(DateOnly.FromDateTime(date.Date.AddDays(7)), TimeOnly.MaxValue);

        return await baseQuery
            .Where(l => l.ClassSubject.TeacherId == teacherId 
                && l.Date >= startDate && l.Date <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Lesson>> GetByClassSubjectAndTermAsync(Guid classId, Guid subjectId, Guid termId)
    {
        var baseQuery = GetAllAsync();
        return await baseQuery
            .Where(l => l.ClassSubject.ClassId == classId 
                && l.ClassSubject.SubjectId == subjectId 
                && l.Schedule.TermId == termId)
            .ToListAsync();
    }
    

    public async Task<IQueryable<Lesson>> GetBySchedule(Guid scheduleId)
    {
        return  GetAllAsync().Where(l => l.ScheduleId == scheduleId);
    }

    public override IQueryable<Lesson> GetAllAsync()
    {
        return _dbSet
            .Include(l => l.ClassSubject)
            .Include(l => l.Schedule);
    }

}
