using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class DirectorService : IDirectorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DirectorService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Director> GetCurrentDirectorAsync()
    {
        var director = await _unitOfWork.Directors.GetCurrentDirectorAsync();
        if (director == null)
        {
            throw new NotFoundException("Директор не найден.");
        }

        return director;
    }

    public async Task CreateDirectorAsync(Director director)
    {
        var existingDirector = await _unitOfWork.Directors.GetDirectorBySchoolIdAsync(director.SchoolId);
        if (existingDirector != null)
        {
            throw new DuplicateException("Директор для данной школы уже существует.");
        }

        await _unitOfWork.Directors.AddAsync(director);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateDirectorAsync(Guid directorId, Director updatedDirector)
    {
        var director = await _unitOfWork.Directors.GetByIdAsync(directorId);
        if (director == null)
        {
            throw new NotFoundException($"Директор с ID {directorId} не найден.");
        }

        _mapper.Map(updatedDirector, director); // Обновляем сущность через маппинг
        _unitOfWork.Directors.Update(director);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteDirectorAsync(Guid directorId)
    {
        var director = await _unitOfWork.Directors.GetByIdAsync(directorId);
        if (director == null)
        {
            throw new NotFoundException($"Директор с ID {directorId} не найден.");
        }

        _unitOfWork.Directors.Remove(director);
        await _unitOfWork.SaveChangesAsync();
    }
}
