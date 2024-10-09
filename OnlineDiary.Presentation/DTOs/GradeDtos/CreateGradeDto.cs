namespace OnlineDiary.Presentation.DTOs.GradeDtos;

public class CreateGradeDto
{
    public Guid StudentId { get; set; }
    public Guid LessonId { get; set; }
    public string Value { get; set; } // Значение оценки
}
