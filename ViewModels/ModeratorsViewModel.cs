using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.Models;

namespace VamaDesktop.ViewModels;

public class ModeratorsViewModel(HistoryRouter<ViewModelBase> router) : RoutedModelBase(router)
{
    public ObservableCollection<ModeratorCardData> ModeratorsData { get; set; } = new()
    {
        new ModeratorCardData

        {
            Nickname = "CoolCat99",
            Description = "Tech enthusiast and meme collector.",
            Logo = "https://picsum.photos/100",
            Subscribers = 1200,
            Likes = 340,
            AccountId = 10,
            CreatedAt = "2023-01-01T09:00:00Z",
            UpdatedAt = "2023-06-01T10:30:00Z",
            Notes = new ObservableCollection<NoteData>
            {
                new NoteData
                {
                    Id = 1,
                    Content = "First note",
                    ArticletId = 101,
                    BannedId = null,
                    CreatedAt = "2023-01-02T10:00:00Z",
                    UpdatedAt = "2023-01-02T10:15:00Z"
                }
            }
        }
    };
}