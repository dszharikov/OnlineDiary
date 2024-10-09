using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class QuarterlySubgradeConfiguration : IEntityTypeConfiguration<QuarterlySubgrade>
{
    public void Configure(EntityTypeBuilder<QuarterlySubgrade> builder)
    {
        builder.ToTable("QuarterlySubgrades");

        builder.HasKey(qs => qs.QuarterlySubgradeId);

        builder.Property(qs => qs.QuarterlySubgradeId)
            .ValueGeneratedOnAdd();

        builder.Property(qs => qs.Value)
            .IsRequired()
            .HasColumnType("decimal(5,2)");

        builder.Property(qs => qs.ClassSubjectId)
            .IsRequired();

        builder.Property(qs => qs.StudentId)
            .IsRequired();

        builder.Property(qs => qs.SubcategoryId)
            .IsRequired();

        // Связь с ClassSubject
        builder.HasOne(qs => qs.ClassSubject)
            .WithMany(cs => cs.QuarterlySubgrades)
            .HasForeignKey(qs => qs.ClassSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с ClassSubject
        builder.HasOne(qs => qs.Student)
            .WithMany(st => st.QuarterlySubgrades)
            .HasForeignKey(qs => qs.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с SubjectSubcategory
        builder.HasOne(qs => qs.SubjectSubcategory)
            .WithMany(ssc => ssc.QuarterlySubgrades)
            .HasForeignKey(qs => qs.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Term
        builder.HasOne(qs => qs.Term)
            .WithMany(t => t.QuarterlySubgrades)
            .HasForeignKey(qs => qs.TermId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на комбинацию QuarterlyGradeId, SubcategoryId и TermId
        builder.HasIndex(qs => new { qs.StudentId, qs.SubcategoryId, qs.TermId })
            .IsUnique();
    }
}
