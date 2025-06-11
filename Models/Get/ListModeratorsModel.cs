using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Models.Get;

public class ListModeratorsModel
{
    public ObservableCollection<ModeratorData>? Moders { get; set; }
}

public record ModeratorData
{
    public int? Id { get; set; }
    public string? Email { get; set; }
    public ObservableCollection<NoteData>? Notes { get; set; }
}