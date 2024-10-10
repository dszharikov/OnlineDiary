using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDiary.Infrastructure.Migrations.School
{
    /// <inheritdoc />
    public partial class InitialSchoolMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "default_schema");

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "default_schema",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClassLevel = table.Column<int>(type: "integer", nullable: false),
                    HomeroomTeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                schema: "default_schema",
                columns: table => new
                {
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactInfo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "default_schema",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "default_schema",
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                schema: "default_schema",
                columns: table => new
                {
                    TermId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermId);
                    table.ForeignKey(
                        name: "FK_Terms_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "default_schema",
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "default_schema",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Director_SchoolId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: true),
                    Student_SchoolId = table.Column<Guid>(type: "uuid", nullable: true),
                    SchoolId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "default_schema",
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Classes_UserId",
                        column: x => x.UserId,
                        principalSchema: "default_schema",
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Schools_Director_SchoolId",
                        column: x => x.Director_SchoolId,
                        principalSchema: "default_schema",
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "default_schema",
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_Users_Schools_Student_SchoolId",
                        column: x => x.Student_SchoolId,
                        principalSchema: "default_schema",
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "ClassLevelSubjects",
                schema: "default_schema",
                columns: table => new
                {
                    ClassLevelSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassLevel = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLevelSubjects", x => x.ClassLevelSubjectId);
                    table.ForeignKey(
                        name: "FK_ClassLevelSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "default_schema",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSubcategories",
                schema: "default_schema",
                columns: table => new
                {
                    SubcategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSubcategories", x => x.SubcategoryId);
                    table.ForeignKey(
                        name: "FK_SubjectSubcategories_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "default_schema",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                schema: "default_schema",
                columns: table => new
                {
                    ClassSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.ClassSubjectId);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "default_schema",
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "default_schema",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "default_schema",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuarterlyGrades",
                schema: "default_schema",
                columns: table => new
                {
                    QuarterlyGradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    TermId = table.Column<Guid>(type: "uuid", nullable: false),
                    OverallGrade = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterlyGrades", x => x.QuarterlyGradeId);
                    table.ForeignKey(
                        name: "FK_QuarterlyGrades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "default_schema",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarterlyGrades_Terms_TermId",
                        column: x => x.TermId,
                        principalSchema: "default_schema",
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarterlyGrades_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "default_schema",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "default_schema",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Room = table.Column<string>(type: "text", nullable: false),
                    TermId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    TeacherUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalSchema: "default_schema",
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "default_schema",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Schedules_Terms_TermId",
                        column: x => x.TermId,
                        principalSchema: "default_schema",
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalSchema: "default_schema",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "QuarterlySubgrades",
                schema: "default_schema",
                columns: table => new
                {
                    QuarterlySubgradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubcategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TermId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    QuarterlyGradeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterlySubgrades", x => x.QuarterlySubgradeId);
                    table.ForeignKey(
                        name: "FK_QuarterlySubgrades_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalSchema: "default_schema",
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarterlySubgrades_QuarterlyGrades_QuarterlyGradeId",
                        column: x => x.QuarterlyGradeId,
                        principalSchema: "default_schema",
                        principalTable: "QuarterlyGrades",
                        principalColumn: "QuarterlyGradeId");
                    table.ForeignKey(
                        name: "FK_QuarterlySubgrades_SubjectSubcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalSchema: "default_schema",
                        principalTable: "SubjectSubcategories",
                        principalColumn: "SubcategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarterlySubgrades_Terms_TermId",
                        column: x => x.TermId,
                        principalSchema: "default_schema",
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuarterlySubgrades_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "default_schema",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                schema: "default_schema",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassSubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Skip = table.Column<bool>(type: "boolean", nullable: false),
                    Topic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalSchema: "default_schema",
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "default_schema",
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "default_schema",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "default_schema",
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "default_schema",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                schema: "default_schema",
                columns: table => new
                {
                    HomeworkId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_Homeworks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "default_schema",
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Name",
                schema: "default_schema",
                table: "Classes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevelSubjects_ClassLevel_SubjectId",
                schema: "default_schema",
                table: "ClassLevelSubjects",
                columns: new[] { "ClassLevel", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassLevelSubjects_SubjectId",
                schema: "default_schema",
                table: "ClassLevelSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ClassId_SubjectId",
                schema: "default_schema",
                table: "ClassSubjects",
                columns: new[] { "ClassId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId",
                schema: "default_schema",
                table: "ClassSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_TeacherId",
                schema: "default_schema",
                table: "ClassSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LessonId",
                schema: "default_schema",
                table: "Grades",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId_LessonId",
                schema: "default_schema",
                table: "Grades",
                columns: new[] { "StudentId", "LessonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                schema: "default_schema",
                table: "Homeworks",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassSubjectId",
                schema: "default_schema",
                table: "Lessons",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ScheduleId",
                schema: "default_schema",
                table: "Lessons",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyGrades_StudentId_SubjectId_TermId",
                schema: "default_schema",
                table: "QuarterlyGrades",
                columns: new[] { "StudentId", "SubjectId", "TermId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyGrades_SubjectId",
                schema: "default_schema",
                table: "QuarterlyGrades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyGrades_TermId",
                schema: "default_schema",
                table: "QuarterlyGrades",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlySubgrades_ClassSubjectId",
                schema: "default_schema",
                table: "QuarterlySubgrades",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlySubgrades_QuarterlyGradeId",
                schema: "default_schema",
                table: "QuarterlySubgrades",
                column: "QuarterlyGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlySubgrades_StudentId_SubcategoryId_TermId",
                schema: "default_schema",
                table: "QuarterlySubgrades",
                columns: new[] { "StudentId", "SubcategoryId", "TermId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlySubgrades_SubcategoryId",
                schema: "default_schema",
                table: "QuarterlySubgrades",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlySubgrades_TermId",
                schema: "default_schema",
                table: "QuarterlySubgrades",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassSubjectId_DayOfWeek_Time_TermId",
                schema: "default_schema",
                table: "Schedules",
                columns: new[] { "ClassSubjectId", "DayOfWeek", "Time", "TermId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                schema: "default_schema",
                table: "Schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherUserId",
                schema: "default_schema",
                table: "Schedules",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TermId",
                schema: "default_schema",
                table: "Schedules",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                schema: "default_schema",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SchoolId",
                schema: "default_schema",
                table: "Subjects",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSubcategories_SubjectId_Name",
                schema: "default_schema",
                table: "SubjectSubcategories",
                columns: new[] { "SubjectId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terms_SchoolId",
                schema: "default_schema",
                table: "Terms",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                schema: "default_schema",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Director_SchoolId",
                schema: "default_schema",
                table: "Users",
                column: "Director_SchoolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName",
                schema: "default_schema",
                table: "Users",
                column: "FirstName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolId",
                schema: "default_schema",
                table: "Users",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_SchoolId",
                schema: "default_schema",
                table: "Users",
                column: "Student_SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassLevelSubjects",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Homeworks",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "QuarterlySubgrades",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Lessons",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "QuarterlyGrades",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "SubjectSubcategories",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "ClassSubjects",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Terms",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Classes",
                schema: "default_schema");

            migrationBuilder.DropTable(
                name: "Schools",
                schema: "default_schema");
        }
    }
}
