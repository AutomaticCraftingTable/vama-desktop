using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Exceptions;

public record RegisterError
{
    [property: JsonPropertyName("email")]
    public string Email { get; set; }
    
    [property: JsonPropertyName("password")]
    public string Password { get; set; }
}