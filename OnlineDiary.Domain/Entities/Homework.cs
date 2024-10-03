namespace OnlineDiary.Domain.Entities;

public class Homework
{
    public Guid HomeworkId { get; set; } // Первичный ключ

    public Guid LessonId { get; set; } // Внешний ключ к Lesson

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    // Навигационные свойства
    public Lesson Lesson { get; set; }
}
