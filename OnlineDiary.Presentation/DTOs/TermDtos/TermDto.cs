namespace OnlineDiary.Presentation.DTOs.TermDtos;

public class TermDto
{
    public Guid TermId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
