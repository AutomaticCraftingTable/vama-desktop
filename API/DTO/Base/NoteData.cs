using System;
using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record NoteData
{
    public int? Id { get; set; }
    public string? Content { get; set; }
    public string? Causer { get; set; }
    [JsonPropertyName("article_id")] public int? ArticleId { get; set; }
    [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTime? UpdatedAt { get; set; }
}