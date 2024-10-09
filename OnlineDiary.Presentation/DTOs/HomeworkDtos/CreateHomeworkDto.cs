namespace OnlineDiary.Presentation.DTOs.HomeworkDtos;

public class CreateHomeworkDto
{
    public Guid LessonId { get; set; } // Внешний ключ к Lesson
    public string Title { get; set; }
    public string Description { get; set; }
}