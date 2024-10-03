namespace OnlineDiary.Domain.Entities;

public class Subject
{
    public Guid SubjectId { get; set; } // Первичный ключ

    public string Name { get; set; }

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public School School { get; set; }

    public ICollection<ClassLevelSubject> ClassLevelSubjects { get; set; } = new List<ClassLevelSubject>();

    public ICollection<SubjectSubcategory> SubjectSubcategories { get; set; } = new List<SubjectSubcategory>();

    public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();
}