namespace OnlineDiary.Presentation.DTOs.DirectorDtos;

public class DirectorDto
{
    public Guid DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public Guid SchoolId { get; set; }
    public string SchoolName { get; set; }
}
