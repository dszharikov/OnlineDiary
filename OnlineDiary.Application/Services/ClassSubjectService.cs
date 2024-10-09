using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;
using AutoMapper;
using OnlineDiary.Application.Exceptions;

namespace OnlineDiary.Application.Services;

public class ClassSubjectService : IClassSubjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassSubjectService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ClassSubject> GetClassSubjectByIdAsync(Guid classSubjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        return classSubject;
    }

    public async Task<IEnumerable<ClassSubject>> GetAllClassSubjectsAsync()
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetAllAsync();
        return classSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsBySubjectIdAsync(Guid subjectId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetBySubjectIdAsync(subjectId);

        return classSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsByTeacherIdAsync(Guid teacherId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetByTeacherIdAsync(teacherId);

        return classSubjects;
    }

    public async Task<IEnumerable<ClassSubject>> GetClassSubjectsByClassIdAsync(Guid classId)
    {
        var classSubjects = await _unitOfWork.ClassSubjects.GetByClassIdAsync(classId);

        return classSubjects;
    }

    public async Task CreateClassSubjectAsync(ClassSubject classSubject)
    {
        await EnsureClassSubjectDoesNotExistAsync(classSubject.ClassId, classSubject.SubjectId);

        await _unitOfWork.ClassSubjects.AddAsync(classSubject);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateClassSubjectAsync(Guid classSubjectId, ClassSubject updatedClassSubject)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        if (updatedClassSubject.ClassId != classSubject.ClassId || updatedClassSubject.SubjectId != classSubject.SubjectId)
        {
            await EnsureClassSubjectDoesNotExistAsync(updatedClassSubject.ClassId, updatedClassSubject.SubjectId);
        }

        _mapper.Map(updatedClassSubject, classSubject);

        _unitOfWork.ClassSubjects.Update(classSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteClassSubjectAsync(Guid classSubjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByIdAsync(classSubjectId);
        if (classSubject == null)
        {
            throw new NotFoundException($"Запись ClassSubject с ID {classSubjectId} не найдена.");
        }

        _unitOfWork.ClassSubjects.Remove(classSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    // Метод проверки на наличие дубликата ClassSubject
    private async Task EnsureClassSubjectDoesNotExistAsync(Guid classId, Guid subjectId)
    {
        var classSubject = await _unitOfWork.ClassSubjects.GetByClassAndSubjectAsync(classId, subjectId);

        if (classSubject != null)
        {
            throw new DuplicateException("Такая запись ClassSubject уже существует.");
        }
    }
}
