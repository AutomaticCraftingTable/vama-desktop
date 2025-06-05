namespace VamaDesktop.API.DTO.Models.Error;

public record AuthError
{
    public string[] Email { get; init; } = [];
    public string[] Password { get; init; } = [];
}