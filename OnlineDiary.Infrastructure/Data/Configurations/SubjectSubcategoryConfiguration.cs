using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class SubjectSubcategoryConfiguration : IEntityTypeConfiguration<SubjectSubcategory>
{
    public void Configure(EntityTypeBuilder<SubjectSubcategory> builder)
    {
        builder.ToTable("SubjectSubcategories");

        builder.HasKey(ssc => ssc.SubcategoryId);

        builder.Property(ssc => ssc.SubcategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(ssc => ssc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ssc => ssc.SubjectId)
            .IsRequired();

        // Связь с Subject
        builder.HasOne(ssc => ssc.Subject)
            .WithMany(s => s.SubjectSubcategories)
            .HasForeignKey(ssc => ssc.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с QuarterlySubgrades
        builder.HasMany(ssc => ssc.QuarterlySubgrades)
            .WithOne(qs => qs.SubjectSubcategory)
            .HasForeignKey(qs => qs.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальный индекс на комбинацию SubjectId и Name
        builder.HasIndex(ss => new { ss.SubjectId, ss.Name })
        .IsUnique();
    }
}
