namespace OnlineDiary.Domain.Entities;

public class ClassSubject
{
    public Guid ClassId { get; set; } // Внешний ключ к Class

    public Guid SubjectId { get; set; } // Внешний ключ к Subject

    public Guid TeacherId { get; set; } // Внешний ключ к Teacher

    // Навигационные свойства
    public Class Class { get; set; }

    public Subject Subject { get; set; }

    public Teacher Teacher { get; set; }

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
