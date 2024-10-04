using OnlineDiary.Domain.Interfaces;
using OnlineDiary.Domain.Interfaces.Repositories;
using OnlineDiary.Infrastructure.Data;

namespace OnlineDiary.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _context;

        public UnitOfWork(SchoolDbContext context,
                          ISchoolRepository schools,
                          IDirectorRepository directors,
                          ITeacherRepository teachers,
                          IStudentRepository students,
                          IClassRepository classes,
                          ISubjectRepository subjects,
                          ISubjectSubcategoryRepository subjectSubcategories,
                          ITermRepository terms,
                          IScheduleRepository schedules,
                          ILessonRepository lessons,
                          IHomeworkRepository homeworks,
                          IGradeRepository grades,
                          IQuarterlyGradeRepository quarterlyGrades,
                          IQuarterlySubgradeRepository quarterlySubgrades,
                          IClassLevelSubjectRepository classLevelSubjects,
                          IClassSubjectRepository classSubjects,
                          IUserRepository users)
        {
            _context = context;

            Schools = schools;
            Directors = directors;
            Teachers = teachers;
            Students = students;
            Classes = classes;
            Subjects = subjects;
            SubjectSubcategories = subjectSubcategories;
            Terms = terms;
            Schedules = schedules;
            Lessons = lessons;
            Homeworks = homeworks;
            Grades = grades;
            QuarterlyGrades = quarterlyGrades;
            QuarterlySubgrades = quarterlySubgrades;
            ClassLevelSubjects = classLevelSubjects;
            ClassSubjects = classSubjects;
            Users = users;
        }

        public ISchoolRepository Schools { get; }
        public IDirectorRepository Directors { get; }
        public ITeacherRepository Teachers { get; }
        public IStudentRepository Students { get; }
        public IClassRepository Classes { get; }
        public ISubjectRepository Subjects { get; }
        public ISubjectSubcategoryRepository SubjectSubcategories { get; }
        public ITermRepository Terms { get; }
        public IScheduleRepository Schedules { get; }
        public ILessonRepository Lessons { get; }
        public IHomeworkRepository Homeworks { get; }
        public IGradeRepository Grades { get; }
        public IQuarterlyGradeRepository QuarterlyGrades { get; }
        public IQuarterlySubgradeRepository QuarterlySubgrades { get; }
        public IClassLevelSubjectRepository ClassLevelSubjects { get; }
        public IClassSubjectRepository ClassSubjects { get; }
        public IUserRepository Users { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
