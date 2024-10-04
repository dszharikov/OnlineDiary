using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("Schools");

        builder.HasKey(s => s.SchoolId);

        builder.Property(s => s.SchoolId)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Address)
            .HasMaxLength(500);

        builder.Property(s => s.ContactInfo)
            .HasMaxLength(200);

        // Связь с Director
        builder.HasOne(s => s.Director)
            .WithOne(d => d.School)
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Teachers
        builder.HasMany(s => s.Teachers)
            .WithOne(t => t.School)
            .HasForeignKey(t => t.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Students
        builder.HasMany(s => s.Students)
            .WithOne(st => st.School)
            .HasForeignKey(st => st.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Subjects
        builder.HasMany(s => s.Subjects)
            .WithOne(sub => sub.School)
            .HasForeignKey(sub => sub.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь с Terms
        builder.HasMany(s => s.Terms)
            .WithOne(t => t.School)
            .HasForeignKey(t => t.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        // Если у вас есть свойство Users в School и User имеет SchoolId
        // builder.HasMany(s => s.Users)
        //     .WithOne(u => u.School)
        //     .HasForeignKey(u => u.SchoolId)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}
