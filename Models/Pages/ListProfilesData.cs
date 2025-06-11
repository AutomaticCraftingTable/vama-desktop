using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace VamaDesktop.Models.Pages;

public record ListProfilesData
{
    public string? State { get; set; }
    public ObservableCollection<ProfileCardData>? Profiles { get; set; }
}