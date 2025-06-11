using System.Text.Json.Serialization;
using VamaDesktop.API.DTO.Interfaces.Body;

namespace VamaDesktop.API.DTO.Models.Body;

public record AuthCredentials: IAuthCredentials
{
    [property: JsonPropertyName("email")]
    public string? Email { get; init; }
    [property: JsonPropertyName("password")]
    public string? Password { get; init; }
    [property: JsonPropertyName("password_confirmation")]
    public string? PasswordConfirmation { get => Password; }
}
