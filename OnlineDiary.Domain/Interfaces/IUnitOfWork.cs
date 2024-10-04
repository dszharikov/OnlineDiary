using System;
using System.Threading.Tasks;
using OnlineDiary.Domain.Interfaces.Repositories;

namespace OnlineDiary.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Репозитории
        ISchoolRepository Schools { get; }
        IUserRepository Users { get; }
        IDirectorRepository Directors { get; }
        ITeacherRepository Teachers { get; }
        IStudentRepository Students { get; }
        IClassRepository Classes { get; }
        ISubjectRepository Subjects { get; }
        ISubjectSubcategoryRepository SubjectSubcategories { get; }
        ITermRepository Terms { get; }
        IScheduleRepository Schedules { get; }
        ILessonRepository Lessons { get; }
        IHomeworkRepository Homeworks { get; }
        IGradeRepository Grades { get; }
        IQuarterlyGradeRepository QuarterlyGrades { get; }
        IQuarterlySubgradeRepository QuarterlySubgrades { get; }
        IClassLevelSubjectRepository ClassLevelSubjects { get; }
        IClassSubjectRepository ClassSubjects { get; }

        // Методы для сохранения изменений
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
