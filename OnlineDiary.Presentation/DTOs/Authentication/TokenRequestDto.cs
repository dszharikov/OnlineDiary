namespace OnlineDiary.Presentation.DTOs.Authentication;

public class TokenRequestDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}