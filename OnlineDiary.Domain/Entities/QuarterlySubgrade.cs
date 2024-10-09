using System.ComponentModel.DataAnnotations;

namespace OnlineDiary.Domain.Entities;

public class QuarterlySubgrade
{
    [Key]
    public Guid QuarterlySubgradeId { get; set; } // Первичный ключ

    public Guid StudentId { get; set; } // Внешний ключ к Student
    public Guid ClassSubjectId { get; set; } // Внешний ключ к ClassSubject

    public Guid SubcategoryId { get; set; } // Внешний ключ к SubjectSubcategory
    public Guid TermId { get; set; } // Внешний ключ к Term

    public decimal Value { get; set; } // Значение оценки

    // Навигационные свойства
    public ClassSubject ClassSubject { get; set; }
    public Student Student { get; set; }
    public Term Term { get; set; }

    public SubjectSubcategory SubjectSubcategory { get; set; }
}
