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

        builder.Property(qs => qs.QuarterlyGradeId)
            .IsRequired();

        builder.Property(qs => qs.SubcategoryId)
            .IsRequired();

        // Уникальный индекс на сочетание QuarterlyGradeId и SubcategoryId
        builder.HasIndex(qs => new { qs.QuarterlyGradeId, qs.SubcategoryId })
            .IsUnique();

        // Связь с QuarterlyGrade
        builder.HasOne(qs => qs.QuarterlyGrade)
            .WithMany(qg => qg.QuarterlySubgrades)
            .HasForeignKey(qs => qs.QuarterlyGradeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с SubjectSubcategory
        builder.HasOne(qs => qs.SubjectSubcategory)
            .WithMany(ssc => ssc.QuarterlySubgrades)
            .HasForeignKey(qs => qs.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на комбинацию QuarterlyGradeId и SubcategoryId
        builder.HasIndex(qs => new { qs.QuarterlyGradeId, qs.SubcategoryId })
            .IsUnique();
    }
}
