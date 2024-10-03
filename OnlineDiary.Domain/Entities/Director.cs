namespace OnlineDiary.Domain.Entities;

public class Director
{
    public Guid DirectorId { get; set; } // Первичный ключ

    public Guid UserId { get; set; } // Внешний ключ к User

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public User User { get; set; }

    public School School { get; set; }
}
