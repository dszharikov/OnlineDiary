using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Filters;
using OnlineDiary.Application.Filters.Students;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Pagination;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFilter<Student> _studentFilter;
    private readonly IPaginationService _paginationService;

    public StudentService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFilter<Student> studentFilter,
        IPaginationService paginationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _studentFilter = studentFilter;
        _paginationService = paginationService;
    }

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new NotFoundException($"Студент с ID {studentId} не найден.");
        }

        return student;
    }

    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(Guid classId)
    {
        var students = await _unitOfWork.Students.GetStudentsByClassIdAsync(classId);

        return students;
    }

    public async Task<PaginationResponseDto<Student>> GetStudentsAsync(
        PaginationAndFilterRequestDto<StudentFilterRequestDto> paginationAndFilterRequest)
    {
        var query = await _unitOfWork.Students.GetAllAsync();

        query = _studentFilter.Apply(query, paginationAndFilterRequest.Filter);

        var paginatedStudents = await _paginationService.PaginateAsync(query, paginationAndFilterRequest.Pagination);
        return paginatedStudents;
    }

    public async Task CreateStudentAsync(Student dto)
    {
        var student = _mapper.Map<Student>(dto);
        await _unitOfWork.Students.AddAsync(student);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Guid studentId, Student updatedStudent)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new NotFoundException($"Студент с ID {studentId} не найден.");
        }

        _mapper.Map(updatedStudent, student); // Обновляем сущность через маппинг
        _unitOfWork.Students.Update(student);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new NotFoundException($"Студент с ID {studentId} не найден.");
        }

        _unitOfWork.Students.Remove(student);

        await _unitOfWork.SaveChangesAsync();
    }
}
