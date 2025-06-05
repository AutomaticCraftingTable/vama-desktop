namespace VamaDesktop.API.DTO.Models.Error;

public record LoginError
{
    public string[] Email { get; init; } = [];
    public string[] Password { get; init; } = [];
}
