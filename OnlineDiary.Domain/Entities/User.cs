namespace OnlineDiary.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } // Первичный ключ

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }

    public UserRole Role { get; set; }

    // Навигационные свойства
    public Director Director { get; set; }
    public Teacher Teacher { get; set; }
    public Student Student { get; set; }
}

public enum UserRole
{
    Director,
    Teacher,
    Student
}
