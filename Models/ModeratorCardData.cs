using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Models;

public record ModeratorCardData
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
    
    public ObservableCollection<NoteData>? Notes { get; init; }
}