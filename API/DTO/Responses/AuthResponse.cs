namespace VamaDesktop.API.DTO.Responses;

public record User
{
    public int? Id { get; init; }
    public required string Email { get; init; }
}

public record AuthResponse
{
    public User User { get; init; }
    public string Token { get; init; }
}
