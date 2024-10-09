using AutoMapper;
using OnlineDiary.Presentation.DTOs.ClassDtos;
using OnlineDiary.Presentation.DTOs.ClassLevelSubjectDtos;
using OnlineDiary.Presentation.DTOs.ClassSubjectDtos;
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
using OnlineDiary.Domain.Entities;

namespace OnlineDiary.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Маппинг для User
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();

        // Маппинг для Term
        CreateMap<Term, TermDto>();
        CreateMap<CreateTermDto, Term>();
        CreateMap<UpdateTermDto, Term>();

        // Маппинг для Class
        CreateMap<Class, ClassDto>()
            .ForMember(dest => dest.HomeroomTeacherName,
                opt => opt.MapFrom(src => src.HomeroomTeacher.FirstName + " " + src.HomeroomTeacher.LastName));
        CreateMap<CreateClassDto, Class>();
        CreateMap<UpdateClassDto, Class>();

        // Маппинг для Teacher
        CreateMap<Teacher, TeacherDto>();
        CreateMap<CreateTeacherDto, Teacher>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.Teacher));
        CreateMap<UpdateTeacherDto, Teacher>();

        // Маппинг для Subject
        CreateMap<Subject, SubjectDto>();
        CreateMap<CreateSubjectDto, Subject>();
        CreateMap<UpdateSubjectDto, Subject>();

        // Маппинг для SubjectSubcategory
        CreateMap<SubjectSubcategory, SubjectSubcategoryDto>()
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));
        CreateMap<CreateSubjectSubcategoryDto, SubjectSubcategory>();
        CreateMap<UpdateSubjectSubcategoryDto, SubjectSubcategory>();

        // Маппинг для Student
        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
        CreateMap<CreateStudentDto, Student>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.Student));
        CreateMap<UpdateStudentDto, Student>();

        // Маппинг для School
        CreateMap<School, SchoolDto>();
        CreateMap<CreateSchoolDto, School>();
        CreateMap<UpdateSchoolDto, School>();

        // Маппинг для ClassLevelSubject
        CreateMap<ClassLevelSubject, ClassLevelSubjectDto>()
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));
        CreateMap<CreateClassLevelSubjectDto, ClassLevelSubject>();
        CreateMap<UpdateClassLevelSubjectDto, ClassLevelSubject>();

        // Маппинг для ClassSubject
        CreateMap<ClassSubject, ClassSubjectDto>()
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName + " " + src.Teacher.LastName));
        CreateMap<CreateClassSubjectDto, ClassSubject>();
        CreateMap<UpdateClassSubjectDto, ClassSubject>();

        // Маппинг для Director
        CreateMap<Director, DirectorDto>()
            .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.School.Name));
        CreateMap<CreateDirectorDto, Director>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.Director));
        CreateMap<UpdateDirectorDto, Director>();

        // Маппинг для Grade
        CreateMap<Grade, GradeDto>();
        CreateMap<CreateGradeDto, Grade>();
        CreateMap<UpdateGradeDto, Grade>();

        // Маппинг для Homework
        CreateMap<Homework, HomeworkDto>()
            .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Lesson.ClassSubject.Subject.Name))
            .ForMember(dest => dest.LessonDate, opt => opt.MapFrom(src => src.Lesson.Date));
        CreateMap<CreateHomeworkDto, Homework>();
        CreateMap<UpdateHomeworkDto, Homework>();
    }
}