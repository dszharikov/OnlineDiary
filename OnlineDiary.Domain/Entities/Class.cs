using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Class
{
    [Key]
    public Guid ClassId { get; set; } // Первичный ключ

    public string Name { get; set; } // Например, "4A"

    public Guid ClassLevelId { get; set; } // Внешний ключ к ClassLevel

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public ClassLevel ClassLevel { get; set; }

    public School School { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();

    public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public HomeroomTeacher HomeroomTeacher { get; set; }

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
