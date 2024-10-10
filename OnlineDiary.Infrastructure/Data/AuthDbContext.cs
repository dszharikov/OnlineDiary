using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Infrastructure.Identity;

namespace OnlineDiary.Infrastructure.Data
{
    public class AuthDbContext : IdentityDbContext<InfrastructureUser, InfrastructureRole, Guid>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    

        // Дополнительные настройки
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Применение конфигураций
            // builder.ApplyConfiguration(new InfrastructureUserConfiguration());
            // builder.ApplyConfiguration(new InfrastructureRoleConfiguration());
        }
    }
}
