namespace OnlineDiary.Domain.Entities;

public class ClassLevelSubject
{
    public Guid ClassLevelId { get; set; } // Внешний ключ к ClassLevel

    public Guid SubjectId { get; set; } // Внешний ключ к Subject

    // Навигационные свойства
    public ClassLevel ClassLevel { get; set; }

    public Subject Subject { get; set; }
}
