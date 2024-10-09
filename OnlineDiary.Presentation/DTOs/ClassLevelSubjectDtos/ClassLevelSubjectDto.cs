namespace OnlineDiary.Presentation.DTOs.ClassLevelSubjectDtos;

public class ClassLevelSubjectDto
{
    public Guid ClassLevelSubjectId { get; set; }
    public int ClassLevel { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
}