namespace OnlineDiary.Domain.Entities;

public class SubjectSubcategory
{
    public Guid SubcategoryId { get; set; } // Первичный ключ

    public Guid SubjectId { get; set; } // Внешний ключ к Subject

    public string Name { get; set; } // Например, "Говорение", "Чтение"

    // Навигационные свойства
    public Subject Subject { get; set; }

    public ICollection<QuarterlySubgrade> QuarterlySubgrades { get; set; } = new List<QuarterlySubgrade>();
}
