namespace OnlineDiary.Presentation.DTOs.StudentDtos;

public class UpdateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public Guid ClassId { get; set; } // Идентификатор класса
}
