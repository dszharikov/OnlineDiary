namespace OnlineDiary.Presentation.DTOs.LessonDtos;

public class LessonDto
{
    public DateTime Date { get; set; }
    public bool Skip { get; set; }
    public string Topic { get; set; }
    public Guid ScheduleId { get; set; }
    public string Room { get; set; }
    public Guid ClassSubjectId { get; set; }
    public Guid ClassId { get; set; }
    public string ClassName { get; set; }
    public Guid TeacherId { get; set; }
    public string TeacherSurname { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
}