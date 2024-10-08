using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SchoolDbContext context) : base(context) { }

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
    }
}
