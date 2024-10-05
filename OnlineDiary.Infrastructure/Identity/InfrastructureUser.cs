using Microsoft.AspNetCore.Identity;

namespace OnlineDiary.Infrastructure.Identity;

public class InfrastructureUser : IdentityUser<Guid>
{
    // Дополнительные свойства
    public Guid SchoolId { get; set; }

    // Навигационные свойства для Identity
    public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
    public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }
}
