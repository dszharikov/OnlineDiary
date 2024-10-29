using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Presentation.DTOs.UserDtos;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Administrator, Director")]
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserDto> _createUserValidator;
    private readonly IValidator<UpdateUserDto> _updateUserValidator;

    public UserController(
        IUserService userService, IMapper mapper,
        IValidator<CreateUserDto> createUserValidator, IValidator<UpdateUserDto> updateUserValidator)
    {
        _userService = userService;
        _mapper = mapper;
        _createUserValidator = createUserValidator;
        _updateUserValidator = updateUserValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        return Ok(_mapper.Map<UserDto>(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        await ValidateAsync(_createUserValidator, userDto);

        var user = _mapper.Map<Domain.Entities.User>(userDto);

        await _userService.CreateUserAsync(user);

        return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserDto userDto)
    {
        await ValidateAsync(_updateUserValidator, userDto);

        var user = _mapper.Map<Domain.Entities.User>(userDto);

        await _userService.UpdateUserAsync(userId, user);

        return Ok();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        await _userService.DeleteUserAsync(userId);

        return Ok();
    }
}
