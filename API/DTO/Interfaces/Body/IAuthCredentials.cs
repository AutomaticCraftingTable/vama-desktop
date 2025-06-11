namespace VamaDesktop.API.DTO.Interfaces.Body;

public interface IAuthCredentials
{
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? PasswordConfirmation { get => Password; }
}