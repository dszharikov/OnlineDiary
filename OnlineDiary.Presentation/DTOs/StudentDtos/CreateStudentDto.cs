namespace OnlineDiary.Presentation.DTOs.StudentDtos;

public class CreateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ClassId { get; set; } // Идентификатор класса
}
