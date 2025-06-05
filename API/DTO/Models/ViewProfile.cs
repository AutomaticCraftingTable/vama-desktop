using System.Collections.Generic;
using System.Text.Json.Serialization;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.API.DTO.Models;

public record ViewArticle
{
    public int Id { get; init; }
    public string Thumbnail { get; init; }
    public int Likes { get; init; }
    public string Tags { get; init; }
    public string Content { get; init; }
    public string Title { get; init; }
    public Profile Author { get; init; }
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

public record ViewComment
{
    public int Id { get; init; }
    public string Causer { get; init; }
    [property: JsonPropertyName("article_id")]
    public int ArticleID { get; init; }
    public string Content { get; init; }
}

public record ViewProfile
{
    public string Nickname { get; init; }
    public string Description { get; init; }
    public string Logo { get; init; }
    public int Subscribers { get; init; }
    public int Likes { get; init; }
    
    public List<ViewComment> Comments { get; init; }
    public List<ViewArticle> Articles { get; init; }
}