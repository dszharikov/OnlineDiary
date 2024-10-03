using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUsernameAsync(string username);
}
