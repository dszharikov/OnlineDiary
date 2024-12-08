namespace OnlineDiary.Presentation.DTOs.ScheduleDtos;

public class CreateScheduleDto
{
    public Guid ClassId { get; set; }
    public Guid SubjectId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Time { get; set; }
    public Guid TermId { get; set; }
    public string Room { get; set; }
}