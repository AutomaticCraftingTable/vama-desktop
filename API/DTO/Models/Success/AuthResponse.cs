using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.DTO.Interfaces.Success;

namespace VamaDesktop.API.DTO.Models.Success;


public record AuthResponse : IAuthResponse
{
    public Account? User { get; init; }
    public string? Token { get; init; }
}
