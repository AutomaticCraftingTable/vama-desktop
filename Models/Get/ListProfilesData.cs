using System.Collections.ObjectModel;

namespace VamaDesktop.Models.Get;

public record ListProfilesData
{
    public string? State { get; set; }
    public ObservableCollection<ProfileCardData>? Profiles { get; set; }
}