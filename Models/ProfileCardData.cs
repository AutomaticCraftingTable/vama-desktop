using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Models;

public record ProfileCardData
{
    public string? Nickname { get; set; }
    [JsonPropertyName("account_id")] public int? AccountId { get; set; }
    public string? Description { get; set; }
    public string? Logo { get; set; }
    public int? Followers { get; set; }
    [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTime? UpdatedAt { get; set; }
    public ObservableCollection<object>? Activities { get; set; }
}