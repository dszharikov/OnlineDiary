using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class School
{
    [Key]
    public Guid SchoolId { get; set; } // Первичный ключ

    public string Name { get; set; }

    public string Address { get; set; }

    public string ContactInfo { get; set; }

    // Навигационные свойства
    public ICollection<User> Users { get; set; } = new List<User>();

    public Director Director { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public ICollection<Student> Students { get; set; } = new List<Student>();

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public ICollection<Term> Terms { get; set; } = new List<Term>();
}
