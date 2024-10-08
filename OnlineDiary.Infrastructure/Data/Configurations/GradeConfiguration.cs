using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");

        builder.HasKey(g => g.GradeId);

        builder.Property(g => g.GradeId)
            .ValueGeneratedOnAdd();

        builder.Property(g => g.Value)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(g => g.StudentId)
            .IsRequired();

        builder.Property(g => g.LessonId)
            .IsRequired();

        // Связь с Student
        builder.HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Lesson
        builder.HasOne(g => g.Lesson)
            .WithMany(l => l.Grades)
            .HasForeignKey(g => g.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на комбинацию StudentId и LessonId
        builder.HasIndex(g => new { g.StudentId, g.LessonId })
            .IsUnique(); 
    }
}
