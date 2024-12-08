using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SchoolDbContext context) : base(context) { }

        public async Task<Schedule> GetByTermClassSubjectDayOfWeekTimeAsync(Guid termId, Guid classSubjectId, DayOfWeek dayOfWeek, TimeOnly time)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .FirstOrDefaultAsync(s => 
                    s.TermId == termId 
                    && s.ClassSubjectId == classSubjectId 
                    && s.DayOfWeek == dayOfWeek 
                    && s.Time == time);
        }

        public async Task<IEnumerable<Schedule>> GetByClassIdAsync(Guid classId)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .Where(s => s.ClassSubject.ClassId == classId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByDayOfWeekAsync(DayOfWeek dayOfWeek)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .Where(s => s.DayOfWeek == dayOfWeek)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTeacherIdAsync(Guid teacherId)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .Where(s => s.ClassSubject.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTermClassAsync(Guid termId, Guid classId)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .Where(s => s.ClassSubject.ClassId == classId && s.TermId == termId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetByTermTeacherAsync(Guid termId, Guid teacherId)
        {
            var allQuery = await GetAllAsync();
            return await allQuery
                .Where(s => s.ClassSubject.TeacherId == teacherId && s.TermId == termId)
                .ToListAsync();
        }

        public override async Task<IQueryable<Schedule>> GetAllAsync()
        {
            return _dbSet
                .Include(s => s.ClassSubject)
                    .ThenInclude(cs => cs.Class)
                .Include(s => s.ClassSubject)
                    .ThenInclude(cs => cs.Subject)
                .Include(s => s.ClassSubject)
                    .ThenInclude(cs => cs.Teacher);
        }
    }
}
