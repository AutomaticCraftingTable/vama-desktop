using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record ArticleData
{
    public int Id { get; init; }
    public string Thumbnail { get; init; }
    public int Likes { get; init; }
    public string Tags { get; init; }
    public string Content { get; init; }
    public string Title { get; init; }
    public API.DTO.Base.Profile Author { get; init; }
    public int Subscribers { get; init; }
    
    [property: JsonPropertyName("account_id")]
    public int AccountId { get; init; }
    [property: JsonPropertyName("banned_at")]
    public string BannedId { get; init; }
    [property: JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
}
