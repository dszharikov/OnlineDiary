using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class QuarterlyGrade
{
    [Key]
    public Guid QuarterlyGradeId { get; set; } // Первичный ключ

    public Guid StudentId { get; set; } // Внешний ключ к Student

    public Guid SubjectId { get; set; } // Внешний ключ к Subject

    public Guid TermId { get; set; } // Внешний ключ к Term

    public decimal? OverallGrade { get; set; } // Общая оценка (может быть NULL)

    public string Comment { get; set; }

    // Навигационные свойства
    public Student Student { get; set; }

    public Subject Subject { get; set; }

    public Term Term { get; set; }

    public ICollection<QuarterlySubgrade> QuarterlySubgrades { get; set; } = new List<QuarterlySubgrade>();
}
