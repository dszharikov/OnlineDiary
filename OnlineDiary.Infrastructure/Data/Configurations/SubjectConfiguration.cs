using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects");

        builder.HasKey(s => s.SubjectId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(s => s.ClassLevelSubjects)
            .WithOne(cls => cls.Subject)
            .HasForeignKey(cls => cls.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.SubjectSubcategories)
            .WithOne(ss => ss.Subject)
            .HasForeignKey(ss => ss.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.ClassSubjects)
            .WithOne(cs => cs.Subject)
            .HasForeignKey(cs => cs.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.QuarterlyGrades)
            .WithOne(qg => qg.Subject)
            .HasForeignKey(qg => qg.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на поле Name
        builder.HasIndex(s => s.Name)
            .IsUnique(); 
    }
}
