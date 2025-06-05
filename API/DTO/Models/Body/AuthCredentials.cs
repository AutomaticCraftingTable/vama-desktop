using VamaDesktop.API.DTO.Interfaces.Body;

namespace VamaDesktop.API.DTO.Models.Body;

public record AuthCredentials: IAuthCredentials
{
    public string? Email { get; init; }
    public string? Password { get; init; }
}
