using Microsoft.Extensions.DependencyInjection;
using OnlineDiary.Application.Filters;
using OnlineDiary.Application.Filters.ClassLevelSubjects;
using OnlineDiary.Application.Filters.ClassSubjects;
using OnlineDiary.Application.Filters.Students;
using OnlineDiary.Application.Filters.Subjects;
using OnlineDiary.Application.Filters.Teachers;
using OnlineDiary.Application.Interfaces;
using OnlineDiary.Application.Services;
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClassLevelSubjectService, ClassLevelSubjectService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<IHomeworkService, HomeworkService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IQuarterlyGradeService, QuarterlyGradeService>();
        services.AddScoped<IQuarterlySubgradeService, QuarterlySubgradeService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ISchoolService, SchoolService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<ISubjectSubcategoryService, SubjectSubcategoryService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ITermService, TermService>();
        services.AddScoped<IUserService, UserService>();

        // filters
        services.AddScoped<IFilter<Teacher>, TeacherFilter>();
        services.AddScoped<IFilter<Subject>, SubjectFilter>();
        services.AddScoped<IFilter<Student>, StudentFilter>();
        services.AddScoped<IFilter<ClassLevelSubject>, ClassLevelSubjectFilter>();
        services.AddScoped<IFilter<ClassSubject>, ClassSubjectFilter>();


        return services;
    }
}