using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Class
{
    [Key]
    public Guid ClassId { get; set; } // Первичный ключ

    public string Name { get; set; } // Например, "2APG-1"

    public int ClassLevel { get; set; } // Уровень класса

    public Guid? HomeroomTeacherId { get; set; } // Внешний ключ к Teacher

    // Навигационные свойства
    public ICollection<Student> Students { get; set; } = new List<Student>();

    public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public Teacher HomeroomTeacher { get; set; }
}
