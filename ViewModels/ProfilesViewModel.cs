using System.Collections.Generic;
using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO.Models;

namespace VamaDesktop.ViewModels;

public class ProfilesViewModel(HistoryRouter<ViewModelBase> router) : RoutedModelBase(router)
{
    public ViewProfile Profile { get; set; } = new()
    {
        Logo = "https://picsum.photos/100",
        Nickname = "nick",
        Subscribers = 1111,
        Likes = 9999,
        Comments = new List<ViewComment>()
        {
            new() { Content = "Comment 1" },
            new() { Content = "Comment 2" },
            new() { Content = "Comment 3" },
        }
    };
}