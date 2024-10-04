using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Infrastructure.Identity;

namespace OnlineDiary.Infrastructure.Data.Configurations.Auth;

public class InfrastructureUserConfiguration : IEntityTypeConfiguration<InfrastructureUser>
{
    public void Configure(EntityTypeBuilder<InfrastructureUser> builder)
    {
        builder.ToTable("Users", "auth");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(u => u.NormalizedUserName)
            .HasDatabaseName("UserNameIndex")
            .IsUnique();

        builder.Property(u => u.Email)
            .HasMaxLength(256);
        
        builder.Property(u => u.SchoolId);

        builder.HasIndex(u => u.NormalizedEmail)
            .HasDatabaseName("EmailIndex");

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        // Навигационные свойства к Claims
        builder.HasMany(e => e.Claims)
            .WithOne()
            .HasForeignKey(c => c.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Навигационные свойства к Logins
        builder.HasMany(e => e.Logins)
            .WithOne()
            .HasForeignKey(l => l.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Навигационные свойства к Tokens
        builder.HasMany(e => e.Tokens)
            .WithOne()
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Навигационные свойства к ролям
        builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(ur => ur.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
