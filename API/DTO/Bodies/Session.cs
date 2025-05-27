namespace VamaDesktop.API.DTO.Bodies;

public class Session
{
    public required string Role { get; init; }
    public required string State { get; init; }
    public required string Token { get; init; }
    public Profile? Profile { get; init; }
}
