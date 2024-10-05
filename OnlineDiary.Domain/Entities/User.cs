namespace OnlineDiary.Domain.Entities;

public abstract class User
{
    public Guid UserId { get; set; } // Primary Key

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }

    public UserRole Role { get; set; }
}

public enum UserRole
{
    Director,
    Teacher,
    Student
}
