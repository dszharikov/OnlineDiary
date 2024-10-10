using FluentValidation;
using OnlineDiary.Presentation.Validations.ClassLevelSubjectValidations;
using OnlineDiary.Presentation.Validations.ClassSubjectValidations;
using OnlineDiary.Presentation.Validations.ClassValidations;
using OnlineDiary.Presentation.Validations.DirectorValidations;
using OnlineDiary.Presentation.Validations.GradeValidations;
using OnlineDiary.Presentation.Validations.HomeworkValidations;
using OnlineDiary.Presentation.Validations.SchoolValidations;
using OnlineDiary.Presentation.Validations.StudentValidations;
using OnlineDiary.Presentation.Validations.SubjectValidations;
using OnlineDiary.Presentation.Validations.SubjectSubcategoryValidations;
using OnlineDiary.Presentation.Validations.TeacherValidations;
using OnlineDiary.Presentation.Validations.TermValidations;
using OnlineDiary.Presentation.Validations.UserValidations;
using OnlineDiary.Presentation.DTOs.ClassLevelSubjectDtos;
using OnlineDiary.Presentation.DTOs.ClassSubjectDtos;
using OnlineDiary.Presentation.DTOs.ClassDtos;
using OnlineDiary.Presentation.DTOs.DirectorDtos;
using OnlineDiary.Presentation.DTOs.GradeDtos;
using OnlineDiary.Presentation.DTOs.HomeworkDtos;
using OnlineDiary.Presentation.DTOs.SchoolDtos;
using OnlineDiary.Presentation.DTOs.StudentDtos;
using OnlineDiary.Presentation.DTOs.SubjectDtos;
using OnlineDiary.Presentation.DTOs.SubjectSubcategoryDtos;
using OnlineDiary.Presentation.DTOs.TeacherDtos;
using OnlineDiary.Presentation.DTOs.TermDtos;
using OnlineDiary.Presentation.DTOs.UserDtos;
using OnlineDiary.Application.Validations.DirectorValidations;

namespace OnlineDiary.Presentation.Extensions;

public static class ValidationServiceCollectionExtensions
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        // ClassLevelSubject Validations
        services.AddScoped<IValidator<CreateClassLevelSubjectDto>, CreateClassLevelSubjectDtoValidator>();
        services.AddScoped<IValidator<UpdateClassLevelSubjectDto>, UpdateClassLevelSubjectDtoValidator>();

        // ClassSubject Validations
        services.AddScoped<IValidator<CreateClassSubjectDto>, CreateClassSubjectDtoValidator>();
        services.AddScoped<IValidator<UpdateClassSubjectDto>, UpdateClassSubjectDtoValidator>();

        // Class Validations
        services.AddScoped<IValidator<CreateClassDto>, CreateClassDtoValidator>();
        services.AddScoped<IValidator<UpdateClassDto>, UpdateClassDtoValidator>();

        // Director Validations
        services.AddScoped<IValidator<CreateDirectorDto>, CreateDirectorDtoValidator>();
        services.AddScoped<IValidator<UpdateDirectorDto>, UpdateDirectorDtoValidator>();

        // Grade Validations
        services.AddScoped<IValidator<CreateGradeDto>, CreateGradeDtoValidator>();
        services.AddScoped<IValidator<UpdateGradeDto>, UpdateGradeDtoValidator>();

        // Homework Validations
        services.AddScoped<IValidator<CreateHomeworkDto>, CreateHomeworkDtoValidator>();
        services.AddScoped<IValidator<UpdateHomeworkDto>, UpdateHomeworkDtoValidator>();

        // School Validations
        services.AddScoped<IValidator<CreateSchoolDto>, CreateSchoolDtoValidator>();
        services.AddScoped<IValidator<UpdateSchoolDto>, UpdateSchoolDtoValidator>();

        // Student Validations
        services.AddScoped<IValidator<CreateStudentDto>, CreateStudentDtoValidator>();
        services.AddScoped<IValidator<UpdateStudentDto>, UpdateStudentDtoValidator>();

        // Subject Validations
        services.AddScoped<IValidator<CreateSubjectDto>, CreateSubjectDtoValidator>();
        services.AddScoped<IValidator<UpdateSubjectDto>, UpdateSubjectDtoValidator>();

        // SubjectSubcategory Validations
        services.AddScoped<IValidator<CreateSubjectSubcategoryDto>, CreateSubjectSubcategoryDtoValidator>();
        services.AddScoped<IValidator<UpdateSubjectSubcategoryDto>, UpdateSubjectSubcategoryDtoValidator>();

        // Teacher Validations
        services.AddScoped<IValidator<CreateTeacherDto>, CreateTeacherDtoValidator>();
        services.AddScoped<IValidator<UpdateTeacherDto>, UpdateTeacherDtoValidator>();

        // Term Validations
        services.AddScoped<IValidator<CreateTermDto>, CreateTermDtoValidator>();
        services.AddScoped<IValidator<UpdateTermDto>, UpdateTermDtoValidator>();

        // User Validations
        services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
        services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();

        return services;
    }
}
