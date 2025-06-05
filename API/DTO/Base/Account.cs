using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record Account
{
    public int? Id { get; init; }
    public string? Email { get; init; }
    [property: JsonPropertyName("email_verified_at")]
    public string? EmailVerifiedAt { get; init; }
    public string? Role { get; init; }
    
    [property: JsonPropertyName("banned_at")]
    public string? BannedAt { get; init; }
    [property: JsonPropertyName("google_id")]
    public string? GoogleId { get; init; }
    [property: JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }
}