using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class TermConfiguration : IEntityTypeConfiguration<Term>
{
    public void Configure(EntityTypeBuilder<Term> builder)
    {
        builder.ToTable("Terms");

        builder.HasKey(t => t.TermId);

        builder.Property(t => t.TermId)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.EndDate)
            .IsRequired();

        builder.Property(t => t.SchoolId)
            .IsRequired();

        // Связь с School
        builder.HasOne(t => t.School)
            .WithMany(s => s.Terms)
            .HasForeignKey(t => t.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с QuarterlyGrades
        builder.HasMany(t => t.QuarterlyGrades)
            .WithOne(qg => qg.Term)
            .HasForeignKey(qg => qg.TermId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
