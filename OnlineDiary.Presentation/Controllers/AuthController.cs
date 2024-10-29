using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Infrastructure.Identity;
using OnlineDiary.Infrastructure.Services.Authentication;
using OnlineDiary.Presentation.DTOs.Authentication;

namespace OnlineDiary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<InfrastructureUser> _userManager;
    private readonly SignInManager<InfrastructureUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly RoleManager<InfrastructureRole> _roleManager;

    public AuthController(
        UserManager<InfrastructureUser> userManager,
        SignInManager<InfrastructureUser> signInManager,
        IJwtTokenGenerator jwtTokenGenerator,
        RoleManager<InfrastructureRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _roleManager = roleManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(loginDto.UserName);

        if (user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            var tokenResponse = await GenerateTokenResponse(user);

            return Ok(tokenResponse);
        }

        return Unauthorized("Invalid username or password");
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequestDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == tokenRequestDto.RefreshToken);

        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return Unauthorized("Invalid refresh token");
        }

        var tokenResponse = await GenerateTokenResponse(user);

        return Ok(tokenResponse);
    }



    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var user = await _userManager.GetUserAsync(User);
        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        await _signInManager.SignOutAsync();
        return Ok("User logged out successfully");
    }

    private async Task<TokenResponseDto> GenerateTokenResponse(InfrastructureUser user)
    {
        // Получаем роли пользователя
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault();

        // Генерация нового AccessToken
        var newAccessToken = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), user.UserName, role, user.SchoolId.ToString());

        // Генерация нового RefreshToken
        var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        // Обновление RefreshToken
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new TokenResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }

}
