using System;
using System.Text.Json.Serialization;

namespace VamaDesktop.Models;

public class ListActivitiesModel{
    public int? Id { get; set; }
    [JsonPropertyName("log_name")] public string? LogName { get; set; }
    public string? Description { get; set; }
    [JsonPropertyName("subject_id")] public int? SubjectId { get; set; }
    [JsonPropertyName("subject_type")] public string? SubjectType { get; set; }
    [JsonPropertyName("causer_id")] public int? CauserId { get; set; }
    [JsonPropertyName("causer_type")] public string? CauserType { get; set; }
    // public Properties? Properties { get; set; }
    public string? Event { get; set; }
    [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTime? UpdatedAt { get; set; }
    public string? Status { get; set; }
}
