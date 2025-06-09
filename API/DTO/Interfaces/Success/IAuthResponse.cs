using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.API.DTO.Interfaces.Success;

public interface IAuthResponse
{
    AccountData? User { get; init; }
    string? Token { get; init; }
}