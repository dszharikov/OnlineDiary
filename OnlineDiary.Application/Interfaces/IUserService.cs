using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IUserService
{
    Task<User> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task CreateUserAsync(User dto);
    Task UpdateUserAsync(Guid userId, User dto);
    Task DeleteUserAsync(Guid userId);
}
