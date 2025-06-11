using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record CommentData
{
    public int Id { get; init; }
    public int Causer { get; init; }
    [property: JsonPropertyName("article_id")]
    public int ArticleId { get; init; }
    public string Content { get; init; }
}