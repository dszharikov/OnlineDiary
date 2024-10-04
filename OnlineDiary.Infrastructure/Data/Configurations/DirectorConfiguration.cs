using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors");

        builder.HasKey(d => d.DirectorId);

        builder.Property(d => d.DirectorId)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.UserId)
            .IsRequired();

        builder.Property(d => d.SchoolId)
            .IsRequired();

        // Связь с User
        builder.HasOne(d => d.User)
            .WithOne(u => u.Director)
            .HasForeignKey<Director>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с School
        builder.HasOne(d => d.School)
            .WithOne(s => s.Director)
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
