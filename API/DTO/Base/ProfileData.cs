using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record ProfileData
{
    public string Nickname { get; init; }
    public string Description { get; init; }
    public string Logo { get; init; }
    public int Subscribers { get; init; }
    public int Likes { get; init; }
    
    [property: JsonPropertyName("account_id")]
    public int AccountId { get; init; }
    [property: JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
}
