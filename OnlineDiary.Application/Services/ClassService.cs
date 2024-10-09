using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class ClassService : IClassService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Class> GetClassByIdAsync(Guid classId)
    {
        var @class = await _unitOfWork.Classes.GetByIdAsync(classId);
        if (@class == null)
        {
            throw new NotFoundException($"Класс с ID {classId} не найден.");
        }

        return @class;
    }

    public async Task<IEnumerable<Class>> GetAllClassesAsync()
    {
        var classes = await _unitOfWork.Classes.GetAllAsync();
        return classes;
    }

    public async Task CreateClassAsync(Class @class)
    {
        await EnsureClassDoesNotExistAsync(@class.Name);

        await _unitOfWork.Classes.AddAsync(@class);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateClassAsync(Guid classId, Class updatedClass)
    {
        var classEntity = await _unitOfWork.Classes.GetByIdAsync(classId);
        if (classEntity == null)
        {
            throw new NotFoundException($"Класс с ID {classId} не найден.");
        }

        if (updatedClass.Name != classEntity.Name)
        {
            await EnsureClassDoesNotExistAsync(updatedClass.Name);
        }

        _mapper.Map(updatedClass, classEntity); // Обновляем сущность через маппинг

        _unitOfWork.Classes.Update(classEntity);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteClassAsync(Guid classId)
    {
        var classEntity = await _unitOfWork.Classes.GetByIdAsync(classId);
        if (classEntity == null)
        {
            throw new NotFoundException($"Класс с ID {classId} не найден.");
        }

        _unitOfWork.Classes.Remove(classEntity);

        await _unitOfWork.SaveChangesAsync();
    }

    // Метод проверки на наличие дубликата ClassLevelSubject
    private async Task EnsureClassDoesNotExistAsync(string className)
    {
        var @class = await _unitOfWork.Classes.GetByNameAsync(className);
        if (@class != null)
        {
            throw new DuplicateException("Класс с таким названием уже существует.");
        }
    }
}
