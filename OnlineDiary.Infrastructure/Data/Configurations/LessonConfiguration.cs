using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");

        builder.HasKey(l => l.LessonId);

        builder.Property(l => l.LessonId)
            .ValueGeneratedOnAdd();

        builder.Property(l => l.Date)
            .IsRequired();

        builder.Property(l => l.Skip)
            .IsRequired();

        builder.Property(l => l.Topic)
            .HasMaxLength(200);

        builder.Property(l => l.ScheduleId)
            .IsRequired();

        builder.Property(l => l.ClassSubjectId)
            .IsRequired();

        // Связь с Schedule
        builder.HasOne(l => l.Schedule)
            .WithMany(s => s.Lessons)
            .HasForeignKey(l => l.ScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Связь с ClassSubject
        builder.HasOne(l => l.ClassSubject)
            .WithMany(cs => cs.Lessons)
            .HasForeignKey(l => l.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Homeworks
        builder.HasMany(l => l.Homeworks)
            .WithOne(h => h.Lesson)
            .HasForeignKey(h => h.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Grades
        builder.HasMany(l => l.Grades)
            .WithOne(g => g.Lesson)
            .HasForeignKey(g => g.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(l => l.Date)
            .IsUnique();
    }
}
