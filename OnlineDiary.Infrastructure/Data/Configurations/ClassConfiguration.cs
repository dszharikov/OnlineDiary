using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.ToTable("Classes");

        builder.HasKey(c => c.ClassId);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.ClassLevel)
            .IsRequired();

        builder.HasOne(c => c.HomeroomTeacher)
            .WithOne(t => t.HomeroomClass)
            .HasForeignKey<Class>(c => c.HomeroomTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Students)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ClassSubjects)
            .WithOne(cs => cs.Class)
            .HasForeignKey(cs => cs.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на поле Name
        builder.HasIndex(c => c.Name)
            .IsUnique();
    }
}
