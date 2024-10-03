namespace OnlineDiary.Domain.Entities;

public class HomeroomTeacher
{
    public Guid ClassId { get; set; } // Внешний ключ к Class

    public Guid TeacherId { get; set; } // Внешний ключ к Teacher

    // Навигационные свойства
    public Class Class { get; set; }

    public Teacher Teacher { get; set; }
}
