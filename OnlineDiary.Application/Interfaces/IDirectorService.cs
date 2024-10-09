using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface IDirectorService
{
    Task<Director> GetCurrentDirectorAsync();
    Task CreateDirectorAsync(Director dto);
    Task UpdateDirectorAsync(Guid directorId, Director dto);
    Task DeleteDirectorAsync(Guid directorId);
}
