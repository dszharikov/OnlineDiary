namespace OnlineDiary.Presentation.DTOs.ClassDtos;

public class CreateClassDto
{
    public string Name { get; set; } // Название класса, например "2APG-1"
    public int ClassLevel { get; set; } // Уровень класса
    public Guid? HomeroomTeacherId { get; set; } // Внешний ключ к учителю
}
