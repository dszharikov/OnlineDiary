using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"Пользователь с ID {userId} не найден.");
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return users;
    }

    public async Task CreateUserAsync(User user)
    {
        await _unitOfWork.Users.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(Guid userId, User updatedUser)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"Пользователь с ID {userId} не найден.");
        }

        _mapper.Map(updatedUser, user); // Обновляем сущность через маппинг
        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException($"Пользователь с ID {userId} не найден.");
        }

        _unitOfWork.Users.Remove(user);

        await _unitOfWork.SaveChangesAsync();
    }
}
