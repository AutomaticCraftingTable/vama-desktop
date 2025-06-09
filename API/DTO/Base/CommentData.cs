using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record CommentData
{
    public int Id { get; init; }
    public string Causer { get; init; }
    [property: JsonPropertyName("article_id")]
    public int ArticleID { get; init; }
    public string Content { get; init; }
}