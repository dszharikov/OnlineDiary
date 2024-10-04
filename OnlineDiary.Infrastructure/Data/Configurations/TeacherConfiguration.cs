using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.TeacherId);

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.SchoolId)
            .IsRequired();

        builder.HasOne(t => t.User)
            .WithOne(u => u.Teacher)
            .HasForeignKey<Teacher>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.School)
            .WithMany(s => s.Teachers)
            .HasForeignKey(t => t.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.ClassSubjects)
            .WithOne(cs => cs.Teacher)
            .HasForeignKey(cs => cs.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Schedules)
            .WithOne(s => s.ClassSubject.Teacher)
            .HasForeignKey(s => s.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Если оставляете связь с HomeroomClass
        builder.HasOne(t => t.HomeroomClass)
            .WithOne(c => c.HomeroomTeacher)
            .HasForeignKey<Class>(c => c.HomeroomTeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
