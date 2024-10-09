using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeacherService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Teacher> GetTeacherByIdAsync(Guid teacherId)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(teacherId);
        if (teacher == null)
        {
            throw new NotFoundException($"Учитель с ID {teacherId} не найден.");
        }

        return teacher;
    }

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        var teachers = await _unitOfWork.Teachers.GetAllAsync();
        return teachers;
    }

    public async Task CreateTeacherAsync(Teacher teacher)
    {
        // TODO: create username and password
        // TODO: create infrastructureUser
        // TODO: set id from infrastructureUser

        await _unitOfWork.Teachers.AddAsync(teacher);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Guid teacherId, Teacher updatedTeacher)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(teacherId);
        if (teacher == null)
        {
            throw new NotFoundException($"Учитель с ID {teacherId} не найден.");
        }

        _mapper.Map(updatedTeacher, teacher); // Обновляем сущность через маппинг
        _unitOfWork.Teachers.Update(teacher);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(Guid teacherId)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(teacherId);
        if (teacher == null)
        {
            throw new NotFoundException($"Учитель с ID {teacherId} не найден.");
        }

        _unitOfWork.Teachers.Remove(teacher);

        await _unitOfWork.SaveChangesAsync();
    }
}
