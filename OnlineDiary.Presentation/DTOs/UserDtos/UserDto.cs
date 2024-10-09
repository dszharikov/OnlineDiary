using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Presentation.DTOs.UserDtos;

public class UserDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
