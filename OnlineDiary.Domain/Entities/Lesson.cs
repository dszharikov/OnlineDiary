using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Lesson
{
    [Key]
    public Guid LessonId { get; set; } // Первичный ключ

    public Guid ScheduleId { get; set; } // Внешний ключ к Schedule
    public Guid ClassSubjectId { get; set; }

    public DateTime Date { get; set; }
    public bool Skip { get; set; }
    public string Topic { get; set; }

    // Навигационные свойства
    public Schedule Schedule { get; set; }
    public ClassSubject ClassSubject { get; set; }

    public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
