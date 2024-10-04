using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class HomeworkRepository : BaseRepository<Homework>, IHomeworkRepository
    {
        public HomeworkRepository(SchoolDbContext context) : base(context) { }

        public async Task<IEnumerable<Homework>> GetByDueDateAsync(DateTime dueDate)
        {
            return await _context.Homeworks.Where(h => h.DueDate == dueDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Homework>> GetByLessonIdAsync(Guid lessonId)
        {
            return await _context.Homeworks.Where(h => h.LessonId == lessonId)
                .ToListAsync();
        }
    }
}
