using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Schedule
{
    [Key]
    public Guid ScheduleId { get; set; } // Первичный ключ

    public Guid ClassSubjectId { get; set; } // Внешний ключ к ClassSubject

    public DayOfWeek DayOfWeek { get; set; }

    public TimeSpan Time { get; set; }

    // Навигационные свойства
    public ClassSubject ClassSubject { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
