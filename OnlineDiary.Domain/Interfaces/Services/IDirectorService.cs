using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Domain.Interfaces.Services;

public interface IDirectorService
{
    Task<Director> GetDirectorByIdAsync(Guid directorId);

    Task<Director> GetDirectorByUserIdAsync(Guid userId);

    Task CreateDirectorAsync(Director director);

    Task UpdateDirectorAsync(Director director);

    Task DeleteDirectorAsync(Guid directorId);
}
