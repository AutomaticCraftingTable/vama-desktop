using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Requests;

public record LoginCredentialsRequest
{
    [property: JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;
    [property: JsonPropertyName("password")]
    public string Password { get; init; } = string.Empty;
}

public record RegisterCredentialsRequest
{
    [property: JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;
    
    [property: JsonPropertyName("password")]
    public string Password { get; init; } = string.Empty;

    [property: JsonPropertyName("password_confirmation")]
    public string PasswordConfirmation { get => Password; }
}