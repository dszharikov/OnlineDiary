using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class ClassLevelSubjectService : IClassLevelSubjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassLevelSubjectService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ClassLevelSubject> GetClassLevelSubjectByIdAsync(Guid classLevelSubjectId)
    {
        var classLevelSubject = await _unitOfWork.ClassLevelSubjects.GetByIdAsync(classLevelSubjectId);
        if (classLevelSubject == null)
        {
            throw new NotFoundException($"Запись ClassLevelSubject с ID {classLevelSubjectId} не найдена.");
        }

        return classLevelSubject;
    }

    public async Task<IEnumerable<ClassLevelSubject>> GetAllClassLevelSubjectsAsync()
    {
        var classLevelSubjects = await _unitOfWork.ClassLevelSubjects.GetAllAsync();
        return classLevelSubjects;
    }

    public async Task<IEnumerable<ClassLevelSubject>> GetClassLevelSubjectsByClassLevelAsync(int classLevel)
    {
        var classLevelSubjects = await _unitOfWork.ClassLevelSubjects.GetByClassLevelAsync(classLevel);
        return classLevelSubjects;
    }

    public async Task CreateClassLevelSubjectAsync(ClassLevelSubject classLevelSubject)
    {
        // Проверяем, что предмет существует
        await EnsureSubjectExistsAsync(classLevelSubject.SubjectId);

        // Проверяем, что такой записи еще нет
        await EnsureClassLevelSubjectDoesNotExistAsync(classLevelSubject.ClassLevel, classLevelSubject.SubjectId);

        await _unitOfWork.ClassLevelSubjects.AddAsync(classLevelSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateClassLevelSubjectAsync(Guid classLevelSubjectId, ClassLevelSubject updatedClassLevelSubject)
    {
        // Проверка, что запись существует
        var classLevelSubject = await _unitOfWork.ClassLevelSubjects.GetByIdAsync(classLevelSubjectId);
        if (classLevelSubject == null)
        {
            throw new NotFoundException($"Запись ClassLevelSubject с ID {classLevelSubjectId} не найдена.");
        }

        // Проверяем, что предмет существует
        if (updatedClassLevelSubject.SubjectId != classLevelSubject.SubjectId)
        {
            await EnsureSubjectExistsAsync(updatedClassLevelSubject.SubjectId);
        }

        // Проверяем, что дубликата записи нет
        await EnsureClassLevelSubjectDoesNotExistAsync(updatedClassLevelSubject.ClassLevel, updatedClassLevelSubject.SubjectId);

        _mapper.Map(updatedClassLevelSubject, classLevelSubject); // Обновляем сущность через маппинг

        _unitOfWork.ClassLevelSubjects.Update(classLevelSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteClassLevelSubjectAsync(Guid classLevelSubjectId)
    {
        var classLevelSubject = await _unitOfWork.ClassLevelSubjects.GetByIdAsync(classLevelSubjectId);
        if (classLevelSubject == null)
        {
            throw new NotFoundException($"Запись ClassLevelSubject с ID {classLevelSubjectId} не найдена.");
        }

        _unitOfWork.ClassLevelSubjects.Remove(classLevelSubject);
        await _unitOfWork.SaveChangesAsync();
    }

    // Метод проверки, что предмет существует
    private async Task EnsureSubjectExistsAsync(Guid subjectId)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);
        if (subject == null)
        {
            throw new NotFoundException($"Предмет с ID {subjectId} не найден.");
        }
    }

    // Метод проверки на наличие дубликата ClassLevelSubject
    private async Task EnsureClassLevelSubjectDoesNotExistAsync(int classLevel, Guid subjectId)
    {
        var classLevelSubject = await _unitOfWork.ClassLevelSubjects.GetByClassLevelAndSubjectAsync(classLevel, subjectId);
        if (classLevelSubject != null)
        {
            throw new DuplicateException("Запись ClassLevelSubject с таким уровнем класса и предметом уже существует.");
        }
    }
}