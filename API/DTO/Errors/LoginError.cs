namespace VamaDesktop.API.DTO.Errors;

public record LoginErrors
{
    public string[] Email { get; init; } = [];
    public string[] Password { get; init; } = [];
}
