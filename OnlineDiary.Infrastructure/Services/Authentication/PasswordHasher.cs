using Microsoft.AspNetCore.Identity;

namespace OnlineDiary.Infrastructure.Services.Authentication;

public class PasswordHasher : IPasswordHasher
{
    private readonly IPasswordHasher<object> _passwordHasher;

    public PasswordHasher()
    {
        _passwordHasher = new PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}