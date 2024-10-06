namespace OnlineDiary.Domain.Entities;

public class ClassLevelSubject
{
    public Guid ClassLevelSubjectId { get; set; } // Первичный ключ
    public int ClassLevel { get; set; } // Внешний ключ к ClassLevel

    public Guid SubjectId { get; set; } // Внешний ключ к Subject

    public Subject Subject { get; set; }
}