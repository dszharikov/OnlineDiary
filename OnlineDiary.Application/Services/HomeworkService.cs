using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class HomeworkService : IHomeworkService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HomeworkService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Homework> GetHomeworkByIdAsync(Guid homeworkId)
    {
        var homework = await _unitOfWork.Homeworks.GetByIdAsync(homeworkId);
        if (homework == null)
        {
            throw new NotFoundException($"Домашняя работа с ID {homeworkId} не найдена.");
        }

        return homework;
    }

    public async Task<IEnumerable<Homework>> GetActualHomeworksByStudentIdAsync(Guid studentId)
    {
        var homeworks = await _unitOfWork.Homeworks.GetActualHomeworkByStudentIdAsync(studentId);

        return homeworks;
    }

    public async Task<Homework> GetHomeworkByLessonIdAsync(Guid lessonId)
    {
        var homework = await _unitOfWork.Homeworks.GetByLessonIdAsync(lessonId);

        return homework;
    }

    public async Task CreateHomeworkAsync(Homework homework)
    {
        var homeworkEntity = await _unitOfWork.Homeworks.GetByLessonIdAsync(homework.LessonId);

        if (homeworkEntity != null)
        {
            throw new DuplicateException("Домашняя работа для данного урока уже существует.");
        }

        await _unitOfWork.Homeworks.AddAsync(homework);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateHomeworkAsync(Guid homeworkId, Homework updatedHomework)
    {
        var homework = await _unitOfWork.Homeworks.GetByIdAsync(homeworkId);
        if (homework == null)
        {
            throw new NotFoundException($"Домашняя работа с ID {homeworkId} не найдена.");
        }

        _mapper.Map(updatedHomework, homework);

        _unitOfWork.Homeworks.Update(homework);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteHomeworkAsync(Guid homeworkId)
    {
        var homework = await _unitOfWork.Homeworks.GetByIdAsync(homeworkId);
        if (homework == null)
        {
            throw new NotFoundException($"Домашняя работа с ID {homeworkId} не найдена.");
        }

        _unitOfWork.Homeworks.Remove(homework);
        await _unitOfWork.SaveChangesAsync();
    }

    
}