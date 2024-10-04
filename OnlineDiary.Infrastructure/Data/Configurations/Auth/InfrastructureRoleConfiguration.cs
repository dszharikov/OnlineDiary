using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineDiary.Infrastructure.Identity;

namespace OnlineDiary.Infrastructure.Data.Configurations.Auth;

public class InfrastructureRoleConfiguration : IEntityTypeConfiguration<InfrastructureRole>
{
    public void Configure(EntityTypeBuilder<InfrastructureRole> builder)
    {
        builder.ToTable("Roles", "auth");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .HasMaxLength(256);

        builder.HasIndex(r => r.NormalizedName)
            .HasDatabaseName("RoleNameIndex")
            .IsUnique();
    }
}
