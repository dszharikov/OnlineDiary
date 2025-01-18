namespace OnlineDiary.Presentation.DTOs.QuarterlyGradeDtos;

public class CreateQuarterlyGradeDto
{
    public Guid StudentId { get; set; }
    public Guid ClassSubjectId { get; set; }
    public Guid TermId { get; set; }
    public decimal? OverallGrade { get; set; }
    public string Comment { get; set; }
}