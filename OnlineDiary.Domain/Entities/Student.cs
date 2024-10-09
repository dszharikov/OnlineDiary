namespace OnlineDiary.Domain.Entities;

public class Student : User
{
    public Guid ClassId { get; set; } // Внешний ключ к Class

    // Навигационные свойства
    public virtual Class Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public virtual ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();
    public virtual ICollection<QuarterlySubgrade> QuarterlySubgrades { get; set; } = new List<QuarterlySubgrade>();
}
