namespace OnlineDiary.Presentation.DTOs.ClassSubjectDtos;

public class CreateClassSubjectDto
{
    public Guid ClassId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid TeacherId { get; set; }
}
