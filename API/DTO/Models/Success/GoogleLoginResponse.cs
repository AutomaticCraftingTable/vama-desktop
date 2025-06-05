using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.DTO.Interfaces.Success;

namespace VamaDesktop.API.DTO.Models.Success;

public record GoogleLoginResponse : IAuthResponse, ICheckGoogleLoginResponse
{
    public string? Status { get; init; }
    public Account? User { get; init; }
    public string? Token { get; init; }
}
