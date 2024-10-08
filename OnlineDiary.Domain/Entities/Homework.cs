using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Homework
{
    [Key]
    public Guid HomeworkId { get; set; } // Первичный ключ

    public Guid LessonId { get; set; } // Внешний ключ к Lesson

    public string Title { get; set; }

    public string Description { get; set; }

    // Навигационные свойства
    public Lesson Lesson { get; set; }
}
