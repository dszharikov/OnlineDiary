using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class QuarterlyGradeConfiguration : IEntityTypeConfiguration<QuarterlyGrade>
{
    public void Configure(EntityTypeBuilder<QuarterlyGrade> builder)
    {
        builder.ToTable("QuarterlyGrades");

        builder.HasKey(qg => qg.QuarterlyGradeId);

        builder.Property(qg => qg.QuarterlyGradeId)
            .ValueGeneratedOnAdd();

        builder.Property(qg => qg.OverallGrade)
            .HasColumnType("decimal(5,2)");

        builder.Property(qg => qg.Comment)
            .HasMaxLength(500);

        builder.Property(qg => qg.StudentId)
            .IsRequired();

        builder.Property(qg => qg.ClassSubjectId)
            .IsRequired();

        builder.Property(qg => qg.TermId)
            .IsRequired();

        // Связь с Student
        builder.HasOne(qg => qg.Student)
            .WithMany(s => s.QuarterlyGrades)
            .HasForeignKey(qg => qg.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с ClassSubject
        builder.HasOne(qg => qg.ClassSubject)
            .WithMany(cs => cs.QuarterlyGrades)
            .HasForeignKey(qg => qg.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Term
        builder.HasOne(qg => qg.Term)
            .WithMany(t => t.QuarterlyGrades)
            .HasForeignKey(qg => qg.TermId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на сочетание StudentId, SubjectId, TermId
        builder.HasIndex(qg => new { qg.StudentId, qg.ClassSubjectId, qg.TermId })
            .IsUnique();
    }
}
