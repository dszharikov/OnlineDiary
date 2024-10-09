using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class ClassSubjectConfiguration : IEntityTypeConfiguration<ClassSubject>
{
    public void Configure(EntityTypeBuilder<ClassSubject> builder)
    {
        builder.ToTable("ClassSubjects");

        builder.HasKey(cs => cs.ClassSubjectId);

        builder.Property(cs => cs.ClassId)
            .IsRequired();

        builder.Property(cs => cs.SubjectId)
            .IsRequired();

        builder.Property(cs => cs.TeacherId)
            .IsRequired();

        builder.HasOne(cs => cs.Class)
            .WithMany(c => c.ClassSubjects)
            .HasForeignKey(cs => cs.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Subject)
            .WithMany(s => s.ClassSubjects)
            .HasForeignKey(cs => cs.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Teacher)
            .WithMany(t => t.ClassSubjects)
            .HasForeignKey(cs => cs.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cs => cs.Schedules)
            .WithOne(s => s.ClassSubject)
            .HasForeignKey(s => s.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cs => cs.Lessons)
            .WithOne(l => l.ClassSubject)
            .HasForeignKey(l => l.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cs => cs.QuarterlySubgrades)
            .WithOne(l => l.ClassSubject)
            .HasForeignKey(l => l.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на комбинацию ClassId и SubjectId
        builder.HasIndex(cs => new { cs.ClassId, cs.SubjectId })
            .IsUnique();
    }
}
