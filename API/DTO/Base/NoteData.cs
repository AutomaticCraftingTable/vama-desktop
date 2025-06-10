using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record NoteData
{
    public int Id { get; init; }
    public string Content { get; init; }
    
    [property: JsonPropertyName("article_id")]
    public int ArticletId { get; init; }
    [property: JsonPropertyName("banned_at")]
    public string BannedId { get; init; }
    [property: JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
}