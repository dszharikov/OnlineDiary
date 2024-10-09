namespace OnlineDiary.Presentation.DTOs.ClassDtos;

public class ClassDto
{
    public Guid ClassId { get; set; } // Идентификатор класса
    public string Name { get; set; } // Название класса
    public int ClassLevel { get; set; } // Уровень класса
    public Guid? HomeroomTeacherId { get; set; } // Внешний ключ к учителю
    public string HomeroomTeacherName { get; set; } // Имя классного руководителя
}
