namespace OnlineDiary.Domain.Entities;

public class Grade
{
    public Guid GradeId { get; set; } // Первичный ключ

    public Guid StudentId { get; set; } // Внешний ключ к Student

    public Guid LessonId { get; set; } // Внешний ключ к Lesson

    public decimal Value { get; set; } // Значение оценки

    public string Comment { get; set; }

    // Навигационные свойства
    public Student Student { get; set; }

    public Lesson Lesson { get; set; }
}
