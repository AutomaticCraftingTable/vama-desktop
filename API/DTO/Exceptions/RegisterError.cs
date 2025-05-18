using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Exceptions;

public record RegisterError
{
    public string Email { get; set; } = "";
    
    public string Password { get; set; } = "";
    public string Regulations { get; set; } = "";
}