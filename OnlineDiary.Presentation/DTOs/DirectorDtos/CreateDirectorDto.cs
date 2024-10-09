namespace OnlineDiary.Presentation.DTOs.DirectorDtos;

public class CreateDirectorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Guid SchoolId { get; set; } // Идентификатор школы
}
