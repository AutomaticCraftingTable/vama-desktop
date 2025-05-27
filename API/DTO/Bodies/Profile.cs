using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO;

public class Profile
{
    public required string Nickname { get; init; }
    public required string Description { get; init; }
    public required string Logo { get; init; }
    public required int Followers { get; init; }
    
    [property: JsonPropertyName("account_id")]
    public required int AccountId { get; init; }
    [property: JsonPropertyName("created_at")]
    public required string CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; init; }
}