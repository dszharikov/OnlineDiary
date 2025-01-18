namespace OnlineDiary.Presentation.DTOs.TermDtos;

public class TermDto
{
    public Guid TermId { get; set; }
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
