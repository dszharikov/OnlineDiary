namespace OnlineDiary.Application.Filters.ClassSubjects;

public class ClassSubjectFilterRequestDto
{
    public Guid ClassId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid SubjectId { get; set; }
}