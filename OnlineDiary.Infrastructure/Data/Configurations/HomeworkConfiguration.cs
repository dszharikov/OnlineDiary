using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.ToTable("Homeworks");

        builder.HasKey(h => h.HomeworkId);

        builder.Property(h => h.HomeworkId)
            .ValueGeneratedOnAdd();

        builder.Property(h => h.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(h => h.LessonId)
            .IsRequired();

        // Связь с Lesson
        builder.HasOne(h => h.Lesson)
            .WithMany(l => l.Homeworks)
            .HasForeignKey(h => h.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на поле LessonId
        builder.HasIndex(h => h.LessonId)
            .IsUnique();
    }
}
