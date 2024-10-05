namespace OnlineDiary.Domain.Entities;

public class School
{
    public Guid SchoolId { get; set; } // Первичный ключ

    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactInfo { get; set; }

    // Навигационные свойства
    public virtual Director Director { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public virtual ICollection<Term> Terms { get; set; } = new List<Term>();
}
