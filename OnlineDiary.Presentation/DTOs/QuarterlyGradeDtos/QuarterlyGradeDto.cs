namespace OnlineDiary.Presentation.DTOs.QuarterlyGradeDtos;

public class QuarterlyGradeDto
{
    public Guid QuarterlyGradeId { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassSubjectId { get; set; }
    public Guid TermId { get; set; }
    public decimal? OverallGrade { get; set; }
    public string Comment { get; set; }
}