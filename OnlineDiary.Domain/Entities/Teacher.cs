using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Teacher
{
    [Key]
    public Guid TeacherId { get; set; } // Первичный ключ

    public Guid UserId { get; set; } // Внешний ключ к User

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public User User { get; set; }

    public School School { get; set; }

    public HomeroomTeacher HomeroomTeacher { get; set; }

    public ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
