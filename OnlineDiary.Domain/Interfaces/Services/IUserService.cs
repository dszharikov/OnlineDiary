using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> AuthenticateAsync(string username, string password);

    Task<User> RegisterAsync(User user, string password);

    Task<User> GetUserByIdAsync(Guid userId);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(Guid userId);
}
