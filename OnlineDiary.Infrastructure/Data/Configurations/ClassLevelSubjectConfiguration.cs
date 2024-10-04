using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class ClassLevelSubjectConfiguration : IEntityTypeConfiguration<ClassLevelSubject>
{
    public void Configure(EntityTypeBuilder<ClassLevelSubject> builder)
    {
        builder.ToTable("ClassLevelSubjects");

        builder.HasKey(cls => cls.ClassLevelSubjectId);

        builder.Property(cls => cls.ClassLevelSubjectId)
            .ValueGeneratedOnAdd();

        builder.Property(cls => cls.ClassLevel)
            .IsRequired();

        builder.Property(cls => cls.SubjectId)
            .IsRequired();

        // Связь с Subject
        builder.HasOne(cls => cls.Subject)
            .WithMany(s => s.ClassLevelSubjects)
            .HasForeignKey(cls => cls.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на сочетание ClassLevel и SubjectId
        builder.HasIndex(cls => new { cls.ClassLevel, cls.SubjectId })
            .IsUnique();
    }
}
