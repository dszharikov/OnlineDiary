namespace OnlineDiary.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } // Первичный ключ

    public string Username { get; set; }

    public string PasswordHash { get; set; } // Зашифрованный пароль

    public UserRole Role { get; set; } // Роли: Director, Teacher, Student

    public Guid? SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public School School { get; set; }

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
