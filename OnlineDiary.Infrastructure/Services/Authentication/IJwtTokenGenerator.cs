namespace OnlineDiary.Infrastructure.Services.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(string userId, string userName, string role, string schoolId);
    string GenerateRefreshToken();
}
