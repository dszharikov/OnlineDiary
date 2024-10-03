using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class ClassLevel
{
    [Key]
    public Guid ClassLevelId { get; set; } // Первичный ключ

    public int Level { get; set; } // Например, 1, 2, 3...

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public School School { get; set; }

    public ICollection<Class> Classes { get; set; } = new List<Class>();

    public ICollection<ClassLevelSubject> ClassLevelSubjects { get; set; } = new List<ClassLevelSubject>();
}
