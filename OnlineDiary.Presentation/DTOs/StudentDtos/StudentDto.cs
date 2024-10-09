namespace OnlineDiary.Presentation.DTOs.StudentDtos;

public class StudentDto
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ClassId { get; set; }
    public string ClassName { get; set; }
}
