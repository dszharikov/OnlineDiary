namespace OnlineDiary.Presentation.DTOs.HomeworkDtos;

public class HomeworkDto
{
    public Guid HomeworkId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime LessonDate { get; set; } // Дата урока
    public string SubjectName { get; set; } // Название предмета
}