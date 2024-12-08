namespace OnlineDiary.Presentation.DTOs.ScheduleDtos;

public class ScheduleDto
{
    public Guid ScheduleId { get; set; }
    public Guid ClassId { get; set; }
    public string ClassName { get; set; }
    public Guid TeacherId { get; set; }
    public string TeacherSurname { get; set; }
    public Guid SubjectId { get; set; }
    public string SubjectName { get; set; }
    public TimeOnly Time { get; set; }
    public string Room { get; set; }
}