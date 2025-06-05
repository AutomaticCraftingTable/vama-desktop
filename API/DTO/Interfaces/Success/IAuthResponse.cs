using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.API.DTO.Interfaces.Success;

public interface IAuthResponse
{
    Account? User { get; init; }
    string? Token { get; init; }
}