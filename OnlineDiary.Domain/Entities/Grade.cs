using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Grade
{
    [Key]
    public Guid GradeId { get; set; } // Первичный ключ

    public Guid StudentId { get; set; } // Внешний ключ к Student

    public Guid LessonId { get; set; } // Внешний ключ к Lesson

    public string Value { get; set; } // Значение оценки

    // Навигационные свойства
    public Student Student { get; set; }

    public Lesson Lesson { get; set; }
}
