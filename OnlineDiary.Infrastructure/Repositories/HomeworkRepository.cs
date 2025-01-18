using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories;

public class HomeworkRepository : BaseRepository<Homework>, IHomeworkRepository
{
    public HomeworkRepository(SchoolDbContext context) : base(context) { }

    public async Task<IEnumerable<Homework>> GetActualHomeworkByStudentIdAsync(Guid studentId)
    {
        var currentDate = DateTime.UtcNow.AddHours(1);

        var homeworks = await _dbSet
            .Where(h => h.Lesson.Date > currentDate
            && h.Lesson.ClassSubject.Class.Students.Any(s => s.UserId == studentId)) // Фильтрация по времени и по студенту
            .Include(h => h.Lesson)
                .ThenInclude(l => l.ClassSubject)
                    .ThenInclude(cs => cs.Subject) // Загрузка связанного предмета
            .OrderBy(h => h.Lesson.Date) // Сортировка по дате урока
            .GroupBy(h => h.Lesson.ClassSubject.Subject) // Группируем по предметам
            .Select(g => g.First()) // Выбираем ближайшую работу для каждого предмета
            .ToListAsync();

        return homeworks;
    }

    public async Task<Homework> GetByLessonIdAsync(Guid lessonId)
    {
        return await _dbSet
            .Include(h => h.Lesson)
                .ThenInclude(l => l.ClassSubject)
                    .ThenInclude(cs => cs.Subject)
                        .FirstOrDefaultAsync(h => h.LessonId == lessonId);
    }
}
