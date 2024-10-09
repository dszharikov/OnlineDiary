namespace OnlineDiary.Presentation.DTOs.GradeDtos;

public class GradeDto
{
    public Guid GradeId { get; set; }
    public Guid StudentId { get; set; }
    public Guid LessonId { get; set; }
    public string Value { get; set; } // Значение оценки
}
