namespace OnlineDiary.Domain.Entities;

public class Director : User
{
    public Guid SchoolId { get; set; } // Foreign Key to School

    // Navigation properties
    public virtual School School { get; set; }
}
