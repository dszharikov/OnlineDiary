using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<Lesson>> GetByDateAsync(DateTime date)
        {
            return await _context.Lessons
                .Where(l => l.Date == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetByScheduleIdAsync(Guid scheduleId)
        {
            return await _context.Lessons
                .Where(l => l.ScheduleId == scheduleId)
                .ToListAsync();
        }
    }
}
