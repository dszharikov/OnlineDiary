using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.HasKey(s => s.SchoolId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        // Relationship with Director (One-to-One)
        builder.HasOne(s => s.Director)
            .WithOne(d => d.School)
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
