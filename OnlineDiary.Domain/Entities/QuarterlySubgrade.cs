using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class QuarterlySubgrade
{
    [Key]
    public Guid QuarterlySubgradeId { get; set; } // Первичный ключ

    public Guid QuarterlyGradeId { get; set; } // Внешний ключ к QuarterlyGrade

    public Guid SubcategoryId { get; set; } // Внешний ключ к SubjectSubcategory

    public decimal Value { get; set; } // Значение оценки

    // Навигационные свойства
    public QuarterlyGrade QuarterlyGrade { get; set; }

    public SubjectSubcategory SubjectSubcategory { get; set; }
}
