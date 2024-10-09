using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        return students;
    }

    public async Task CreateStudentAsync(Student dto)
    {
        // TODO: create username and password
        // TODO: set id from infrastructureUser

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
