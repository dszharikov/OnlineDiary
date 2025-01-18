using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Filters;
using OnlineDiary.Application.Filters.Teachers;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;
    private readonly IFilter<Teacher> _teacherFilter;

    public TeacherService(
        IUnitOfWork unitOfWork,
        IMapper mapper, 
        IPaginationService paginationService,
        IFilter<Teacher> teacherFilter)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _paginationService = paginationService;
        _teacherFilter = teacherFilter;
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

    public async Task<PaginationResponseDto<Teacher>> GetTeachersAsync(
        PaginationAndFilterRequestDto<TeacherFilterRequestDto> paginationRequestDto)
    {
        var query = _unitOfWork.Teachers.GetAllAsync();

        query = _teacherFilter.Apply(query, paginationRequestDto.Filter);

        var paginatedTeachers = await _paginationService.PaginateAsync(query, paginationRequestDto.Pagination);
        return paginatedTeachers;
    }

    public async Task CreateTeacherAsync(Teacher teacher)
    {
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
