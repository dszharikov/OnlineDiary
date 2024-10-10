namespace OnlineDiary.Application.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    string UserName { get; }
    string Role { get; }
    string SchoolId { get; }
    bool IsAuthenticated { get; }
}
