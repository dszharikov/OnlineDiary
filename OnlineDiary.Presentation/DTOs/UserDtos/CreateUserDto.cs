using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Presentation.DTOs.UserDtos;

public class CreateUserDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserRole Role { get; set; }
}
