﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineDiary.Infrastructure.Data;

#nullable disable

namespace OnlineDiary.Infrastructure.Migrations.School
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("default_schema")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Class", b =>
                {
                    b.Property<Guid>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ClassLevel")
                        .HasColumnType("integer");

                    b.Property<Guid?>("HomeroomTeacherId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ClassId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Classes", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.ClassLevelSubject", b =>
                {
                    b.Property<Guid>("ClassLevelSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ClassLevel")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("ClassLevelSubjectId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("ClassLevel", "SubjectId")
                        .IsUnique();

                    b.ToTable("ClassLevelSubjects", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.ClassSubject", b =>
                {
                    b.Property<Guid>("ClassSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("ClassSubjectId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("ClassId", "SubjectId")
                        .IsUnique();

                    b.ToTable("ClassSubjects", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Grade", b =>
                {
                    b.Property<Guid>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("GradeId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId", "LessonId")
                        .IsUnique();

                    b.ToTable("Grades", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Homework", b =>
                {
                    b.Property<Guid>("HomeworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("HomeworkId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Homeworks", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Skip")
                        .HasColumnType("boolean");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("LessonId");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Lessons", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.QuarterlyGrade", b =>
                {
                    b.Property<Guid>("QuarterlyGradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal?>("OverallGrade")
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TermId")
                        .HasColumnType("uuid");

                    b.HasKey("QuarterlyGradeId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TermId");

                    b.HasIndex("StudentId", "SubjectId", "TermId")
                        .IsUnique();

                    b.ToTable("QuarterlyGrades", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.QuarterlySubgrade", b =>
                {
                    b.Property<Guid>("QuarterlySubgradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("QuarterlyGradeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubcategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TermId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("QuarterlySubgradeId");

                    b.HasIndex("ClassSubjectId");

                    b.HasIndex("QuarterlyGradeId");

                    b.HasIndex("SubcategoryId");

                    b.HasIndex("TermId");

                    b.HasIndex("StudentId", "SubcategoryId", "TermId")
                        .IsUnique();

                    b.ToTable("QuarterlySubgrades", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassSubjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeacherUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TermId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("interval");

                    b.HasKey("ScheduleId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherUserId");

                    b.HasIndex("TermId");

                    b.HasIndex("ClassSubjectId", "DayOfWeek", "Time", "TermId")
                        .IsUnique();

                    b.ToTable("Schedules", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.School", b =>
                {
                    b.Property<Guid>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasKey("SubjectId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SchoolId");

                    b.ToTable("Subjects", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.SubjectSubcategory", b =>
                {
                    b.Property<Guid>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("SubcategoryId");

                    b.HasIndex("SubjectId", "Name")
                        .IsUnique();

                    b.ToTable("SubjectSubcategories", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Term", b =>
                {
                    b.Property<Guid>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TermId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Terms", "default_schema");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users", "default_schema");

                    b.HasDiscriminator<int>("Role");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Director", b =>
                {
                    b.HasBaseType("OnlineDiary.Domain.Entities.User");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasIndex("FirstName")
                        .IsUnique();

                    b.HasIndex("SchoolId")
                        .IsUnique();

                    b.ToTable("Users", "default_schema", t =>
                        {
                            t.Property("SchoolId")
                                .HasColumnName("Director_SchoolId");
                        });

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Student", b =>
                {
                    b.HasBaseType("OnlineDiary.Domain.Entities.User");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasIndex("ClassId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users", "default_schema", t =>
                        {
                            t.Property("SchoolId")
                                .HasColumnName("Student_SchoolId");
                        });

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Teacher", b =>
                {
                    b.HasBaseType("OnlineDiary.Domain.Entities.User");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasIndex("SchoolId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.ClassLevelSubject", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Subject", "Subject")
                        .WithMany("ClassLevelSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.ClassSubject", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Class", "Class")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Subject", "Subject")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Teacher", "Teacher")
                        .WithMany("ClassSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Grade", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Lesson", "Lesson")
                        .WithMany("Grades")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Homework", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Lesson", "Lesson")
                        .WithMany("Homeworks")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Lesson", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.ClassSubject", "ClassSubject")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Schedule", "Schedule")
                        .WithMany("Lessons")
                        .HasForeignKey("ScheduleId")
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.QuarterlyGrade", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Student", "Student")
                        .WithMany("QuarterlyGrades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Subject", "Subject")
                        .WithMany("QuarterlyGrades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Term", "Term")
                        .WithMany("QuarterlyGrades")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.QuarterlySubgrade", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.ClassSubject", "ClassSubject")
                        .WithMany("QuarterlySubgrades")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.QuarterlyGrade", null)
                        .WithMany("QuarterlySubgrades")
                        .HasForeignKey("QuarterlyGradeId");

                    b.HasOne("OnlineDiary.Domain.Entities.Student", "Student")
                        .WithMany("QuarterlySubgrades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.SubjectSubcategory", "SubjectSubcategory")
                        .WithMany("QuarterlySubgrades")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Term", "Term")
                        .WithMany("QuarterlySubgrades")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Student");

                    b.Navigation("SubjectSubcategory");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.ClassSubject", "ClassSubject")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.Subject", null)
                        .WithMany("Schedules")
                        .HasForeignKey("SubjectId");

                    b.HasOne("OnlineDiary.Domain.Entities.Teacher", null)
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherUserId");

                    b.HasOne("OnlineDiary.Domain.Entities.Term", "Term")
                        .WithMany("Schedules")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassSubject");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Subject", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.School", null)
                        .WithMany("Subjects")
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.SubjectSubcategory", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Subject", "Subject")
                        .WithMany("SubjectSubcategories")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Term", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.School", null)
                        .WithMany("Terms")
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Director", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.School", "School")
                        .WithOne("Director")
                        .HasForeignKey("OnlineDiary.Domain.Entities.Director", "SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Student", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineDiary.Domain.Entities.School", null)
                        .WithMany("Students")
                        .HasForeignKey("SchoolId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("OnlineDiary.Domain.Entities.School", null)
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolId");

                    b.HasOne("OnlineDiary.Domain.Entities.Class", "HomeroomClass")
                        .WithOne("HomeroomTeacher")
                        .HasForeignKey("OnlineDiary.Domain.Entities.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("HomeroomClass");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Class", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("HomeroomTeacher")
                        .IsRequired();

                    b.Navigation("Students");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.ClassSubject", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("QuarterlySubgrades");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Lesson", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Homeworks");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.QuarterlyGrade", b =>
                {
                    b.Navigation("QuarterlySubgrades");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.School", b =>
                {
                    b.Navigation("Director")
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");

                    b.Navigation("Terms");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Subject", b =>
                {
                    b.Navigation("ClassLevelSubjects");

                    b.Navigation("ClassSubjects");

                    b.Navigation("QuarterlyGrades");

                    b.Navigation("Schedules");

                    b.Navigation("SubjectSubcategories");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.SubjectSubcategory", b =>
                {
                    b.Navigation("QuarterlySubgrades");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Term", b =>
                {
                    b.Navigation("QuarterlyGrades");

                    b.Navigation("QuarterlySubgrades");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Student", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("QuarterlyGrades");

                    b.Navigation("QuarterlySubgrades");
                });

            modelBuilder.Entity("OnlineDiary.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("ClassSubjects");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
