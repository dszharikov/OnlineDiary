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

    public async Task<IEnumerable<Lesson>> GetLessonsByTeacherForWeekAsync(Guid teacherId, DateTime date)
    {
        var lessons = await _unitOfWork.Lessons.GetByTeacherForWeekAsync(teacherId, date);

        return lessons;
    }
    public async Task<IEnumerable<Lesson>> GetLessonsByClassForWeekAsync(Guid classId, DateTime date)
    {
        var lessons = await _unitOfWork.Lessons.GetByClassForWeekAsync(classId, date);

        return lessons;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsByClassSubjectAndTermAsync(Guid classId, Guid subjectId, Guid termId)
    {
        var lessons = await _unitOfWork.Lessons.GetByClassSubjectAndTermAsync(classId, subjectId, termId);

        return lessons;
    }

    public async Task CreateLessonsByScheduleAsync(Schedule schedule)
    {
        if (schedule == null)
        {
            throw new NotFoundException($"Расписание не найдено.");
        }

        var term = await _unitOfWork.Terms.GetByIdAsync(schedule.TermId);

        DateTime startDate;
        // choose if the term has already started. Set time from schedule
        if (term.StartDate.ToDateTime(schedule.Time) > DateTime.Now)
        {
            startDate = term.StartDate.ToDateTime(schedule.Time);
        }
        else
        {
            startDate = new DateTime(DateOnly.FromDateTime(DateTime.Now), schedule.Time);
        }
        // set first lesson date from today or from the begging of the term
        startDate.AddDays(((int)schedule.DayOfWeek - (int)startDate.DayOfWeek + 7) % 7);

        var endDate = term.EndDate.ToDateTime(TimeOnly.MaxValue);

        var lessons = new List<Lesson>();

        for (var date = startDate; date <= endDate; date = date.AddDays(7))
        {
            var lesson = new Lesson
            {
                ScheduleId = schedule.ScheduleId,
                ClassSubjectId = schedule.ClassSubjectId,
                Date = date,
            };

            lessons.Add(lesson);
        }

        await _unitOfWork.Lessons.AddRangeAsync(lessons);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateLessonsByScheduleAsync(Schedule schedule, TimeOnly newTime)
    {
        var lessons = (await _unitOfWork.Lessons.GetBySchedule(schedule.ScheduleId))
            .Where(l => l.Date >= DateTime.Now).ToList();


        if (lessons == null)
        {
            throw new NotFoundException($"Запись Lesson с ScheduleId {schedule.ScheduleId}");
        }

        foreach (var lesson in lessons)
        {
            lesson.Date = new DateTime(DateOnly.FromDateTime(lesson.Date), newTime);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateLessonAsync(Guid lessonId, Lesson lesson)
    {
        var lessonEntity = await _unitOfWork.Lessons.GetByIdAsync(lessonId);

        if (lessonEntity == null)
        {
            throw new NotFoundException($"Запись Lesson с ID {lessonId} не найдена.");
        }

        _mapper.Map(lesson, lessonEntity);

        _unitOfWork.Lessons.Update(lessonEntity);

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