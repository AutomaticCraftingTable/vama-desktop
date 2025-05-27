namespace VamaDesktop.API.DTO.Errors;

public record RegisterError
{
    public string[] Email { get; init; } = [];
    public string[] Password { get; init; } = [];
}