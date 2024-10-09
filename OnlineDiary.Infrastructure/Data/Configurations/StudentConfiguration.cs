using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Relationship with Class (Many-to-One)
            builder.HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(st => st.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(st => st.QuarterlyGrades)
                .WithOne(qg => qg.Student)
                .HasForeignKey(qg => qg.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(st => st.QuarterlySubgrades)
                .WithOne(qs => qs.Student)
                .HasForeignKey(qs => qs.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
