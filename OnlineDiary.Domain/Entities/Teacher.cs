namespace OnlineDiary.Domain.Entities;

public class Teacher : User
{
    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public virtual School School { get; set; }

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Class HomeroomClass { get; set; }
}
