namespace OnlineDiary.Domain.Entities;

public class Lesson
{
    public Guid LessonId { get; set; } // Первичный ключ

    public Guid ScheduleId { get; set; } // Внешний ключ к Schedule

    public DateTime Date { get; set; }

    public string Topic { get; set; }

    // Навигационные свойства
    public Schedule Schedule { get; set; }

    public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
