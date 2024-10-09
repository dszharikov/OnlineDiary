namespace OnlineDiary.Presentation.DTOs.ClassDtos;

public class UpdateClassDto
{
    public string Name { get; set; } // Название класса
    public int ClassLevel { get; set; } // Уровень класса
    public Guid? HomeroomTeacherId { get; set; } // Внешний ключ к учителю
}
