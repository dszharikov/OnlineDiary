using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SchoolDbContext context) : base(context) { }

        public async Task<Schedule> GetByTermClassSubjectDayOfWeekTimeAsync(Guid termId, Guid classSubjectId, DayOfWeek dayOfWeek, TimeSpan time)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => 
                    s.TermId == termId 
                    && s.ClassSubjectId == classSubjectId 
                    && s.DayOfWeek == dayOfWeek 
                    && s.Time == time);
        }

        public async Task<IEnumerable<Schedule>> GetByClassIdAsync(Guid classId)
        {
            return await _dbSet
                .Where(s => s.ClassSubject.ClassId == classId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek)
        {
            return await _dbSet
                .Where(s => s.DayOfWeek == dayOfWeek)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTeacherIdAsync(Guid teacherId)
        {
            return await _dbSet
                .Where(s => s.ClassSubject.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTermClassAsync(Guid termId, Guid classId)
        {
            return await _dbSet
                .Where(s => s.ClassSubject.ClassId == classId && s.TermId == termId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTermTeacherAsync(Guid termId, Guid teacherId)
        {
            return await _dbSet
                .Where(s => s.ClassSubject.TeacherId == teacherId && s.TermId == termId)
                .ToListAsync();
        }
    }
}
