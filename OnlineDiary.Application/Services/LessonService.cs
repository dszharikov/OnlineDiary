using AutoMapper;
using OnlineDiary.Application.Exceptions;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Domain.Interfaces;

namespace OnlineDiary.Application.Services;

public class LessonService : ILessonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<Lesson> GetLessonByIdAsync(Guid lessonId)
    {
        var lesson = _unitOfWork.Lessons.GetByIdAsync(lessonId);

        if (lesson is null)
        {
            throw new NotFoundException($"Запись Lesson с ID {lessonId} не найдена.");
        }

        return lesson;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByClassSubjectIdAndTermIdAsync(Guid classSubjectId, Guid termId)
    {
        var lessons = await _unitOfWork.Lessons.GetByClassSubjectIdAndTermIdAsync(classSubjectId, termId);

        return lessons;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByDateAsync(DateTime date)
    {
        var lessons = await _unitOfWork.Lessons.GetByDateAsync(date);

        return lessons;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByDateRangeAndStudentIdAsync(DateTime startDate, DateTime endDate, Guid classId)
    {
        var lessons = await _unitOfWork.Lessons.GetByDateRangeAndStudentIdAsync(startDate, endDate, classId);

        return lessons;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByDateRangeAndTeacherIdAsync(DateTime startDate, DateTime endDate, Guid teacherId)
    {
        var lessons = await _unitOfWork.Lessons.GetByDateRangeAndTeacherIdAsync(startDate, endDate, teacherId);

        return lessons;
    }

    public async Task CreateLessonAsync(Lesson lesson)
    {
        var lessonEntity = _unitOfWork.Lessons.GetByScheduleAndDateAsync(lesson.ScheduleId, lesson.Date);

        if (lessonEntity != null)
        {
            throw new DuplicateException("Запись Lesson с таким расписанием и датой уже существует.");
        }

        await _unitOfWork.Lessons.AddAsync(lesson);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateLessonAsync(Guid lessonId, Lesson updatedLesson)
    {
        var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);

        if (lesson == null)
        {
            throw new NotFoundException($"Запись Lesson с ID {lessonId} не найдена.");
        }

        _mapper.Map(updatedLesson, lesson);

        _unitOfWork.Lessons.Update(lesson);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteLessonAsync(Guid lessonId)
    {
        var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);

        if (lesson == null)
        {
            throw new NotFoundException($"Запись Lesson с ID {lessonId} не найдена.");
        }

        _unitOfWork.Lessons.Remove(lesson);

        await _unitOfWork.SaveChangesAsync();
    }
}