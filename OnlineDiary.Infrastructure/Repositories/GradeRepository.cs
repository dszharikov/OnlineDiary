using Microsoft.EntityFrameworkCore;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.Repositories
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(SchoolDbContext context) : base(context) { }

        // Получить оценки студента за учебный период
        public async Task<IEnumerable<Grade>> GetGradesForStudentByTermAsync(Guid studentId, Guid termId)
        {
            return await _dbSet
                .Include(g => g.Lesson)
                .ThenInclude(l => l.Schedule)
                .Where(g => g.StudentId == studentId && g.Lesson.Schedule.TermId == termId)
                .ToListAsync();
        }

        // Получить оценки по конкретному уроку за учебный период
        public async Task<IEnumerable<Grade>> GetGradesByClassSubjectAndTermAsync(Guid classSubjectId, Guid termId)
        {
            var grades = await _dbSet
                .Include(g => g.Lesson) // Подключаем уроки
                .ThenInclude(l => l.Schedule) // Подключаем расписание
                .Where(g => g.Lesson.ClassSubjectId == classSubjectId && g.Lesson.Schedule.TermId == termId) // Фильтрация по ClassSubjectId и TermId
                .ToListAsync();

            return grades;
        }
    }
}
