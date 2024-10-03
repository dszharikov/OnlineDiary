namespace OnlineDiary.Domain.Entities;

public class Student
{
    public Guid StudentId { get; set; } // Первичный ключ

    public Guid UserId { get; set; } // Внешний ключ к User

    public Guid ClassId { get; set; } // Внешний ключ к Class

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public User User { get; set; }

    public Class Class { get; set; }

    public School School { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();
}
