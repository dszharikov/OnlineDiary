using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        // Relationship with School (One-to-One)
        builder.HasOne(d => d.School)
            .WithOne(s => s.Director)
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Уникальный индекс на поле FirstName, так как директор может быть только один
        builder.HasIndex(d => d.FirstName)
            .IsUnique();
    }
}
