using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // TPH Configuration with Discriminator
            builder.HasDiscriminator<UserRole>("Role")
                .HasValue<Director>(UserRole.Director)
                .HasValue<Teacher>(UserRole.Teacher)
                .HasValue<Student>(UserRole.Student);

            // Primary Key
            builder.HasKey(u => u.UserId);

            // Properties
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
