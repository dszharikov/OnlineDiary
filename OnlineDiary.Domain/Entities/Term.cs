using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class Term
{
    [Key]
    public Guid TermId { get; set; } // Первичный ключ

    public string Name { get; set; } // Например, "Первый семестр"

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    // Навигационные свойства
    public ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<QuarterlySubgrade> QuarterlySubgrades { get; set; } = new List<QuarterlySubgrade>();
}
