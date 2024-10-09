using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    UserRole Role { get; }
}