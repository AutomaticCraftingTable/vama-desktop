using VamaDesktop.API.DTO.Interfaces.Success;

namespace VamaDesktop.API.DTO.Models.Success;

public record InitGoogleLoginResponse: IInitGoogleLoginResponse
{
    public string? State { get; init; }
    public string? Redirect_url { get; init; }
}