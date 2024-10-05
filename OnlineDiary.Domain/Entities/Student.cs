namespace OnlineDiary.Domain.Entities;

public class Student : User
{
    public Guid ClassId { get; set; } // Внешний ключ к Class
    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public virtual Class Class { get; set; }
    public virtual School School { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public virtual ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();
}
