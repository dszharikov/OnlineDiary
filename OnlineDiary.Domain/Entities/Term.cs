namespace OnlineDiary.Domain.Entities;

public class Term
{
    public Guid TermId { get; set; } // Первичный ключ

    public string Name { get; set; } // Например, "Первый семестр"

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid SchoolId { get; set; } // Внешний ключ к School

    // Навигационные свойства
    public School School { get; set; }

    public ICollection<QuarterlyGrade> QuarterlyGrades { get; set; } = new List<QuarterlyGrade>();
}
