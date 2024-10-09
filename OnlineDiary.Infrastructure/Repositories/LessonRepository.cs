using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(SchoolDbContext context) : base(context) { }

        public Task<IEnumerable<Lesson>> GetByClassSubjectIdAndTermIdAsync(Guid classSubjectId, Guid termId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetByDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(l => l.Date == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetByDateRangeAndStudentIdAsync(DateTime startDate, DateTime endDate, Guid classId)
        {
            return await _dbSet
                .Where(l => l.Date >= startDate && l.Date <= endDate && l.ClassSubject.ClassId == classId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetByDateRangeAndTeacherIdAsync(DateTime startDate, DateTime endDate, Guid teacherId)
        {
            return await _dbSet
                .Where(l => l.Date >= startDate && l.Date <= endDate && l.ClassSubject.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<Lesson> GetByScheduleAndDateAsync(Guid scheduleId, DateTime date)
        {
            return await _dbSet
                .FirstOrDefaultAsync(l => l.ScheduleId == scheduleId && l.Date == date);
        }
    }
}
