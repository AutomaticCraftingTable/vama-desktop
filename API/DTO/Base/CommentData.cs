using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record CommentData
{
    public int Id { get; set; }
    public int Causer { get; set; }
    [property: JsonPropertyName("article_id")]
    public int ArticleId { get; set; }
    public string Content { get; set; }
}


