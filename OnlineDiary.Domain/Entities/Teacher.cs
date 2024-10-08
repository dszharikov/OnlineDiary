namespace OnlineDiary.Domain.Entities;

public class Teacher : User
{
    // Навигационные свойства
    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Class HomeroomClass { get; set; }
}
