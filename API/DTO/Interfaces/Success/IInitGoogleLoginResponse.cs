namespace VamaDesktop.API.DTO.Interfaces.Success;

public interface IInitGoogleLoginResponse
{
    public string? State { get; init; }
    public string? Redirect_url { get; init; }
}