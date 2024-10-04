using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.StudentId);

        builder.Property(s => s.UserId)
            .IsRequired();

        builder.Property(s => s.ClassId)
            .IsRequired();

        builder.Property(s => s.SchoolId)
            .IsRequired();

        builder.HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Class)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.School)
            .WithMany(sch => sch.Students)
            .HasForeignKey(s => s.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Grades)
            .WithOne(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.QuarterlyGrades)
            .WithOne(qg => qg.Student)
            .HasForeignKey(qg => qg.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
