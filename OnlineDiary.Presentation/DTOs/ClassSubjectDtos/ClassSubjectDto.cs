namespace OnlineDiary.Presentation.DTOs.ClassSubjectDtos;

public class ClassSubjectDto
{
    public Guid ClassSubjectId { get; set; }
    public Guid ClassId { get; set; }
    public string ClassName { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
}