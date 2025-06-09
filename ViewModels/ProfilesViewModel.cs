using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.Models;

namespace VamaDesktop.ViewModels;

public class ProfilesViewModel(HistoryRouter<ViewModelBase> router) : RoutedModelBase(router)
{
    public IList<ProfileCardData> ProfilesData { get; set; } = new List<ProfileCardData>
    {
        new()
        {
            Logo = "https://picsum.photos/100",
            Nickname = "david",
            Subscribers = 1111,
            Likes = 9999,
            Comments = new ObservableCollection<CommentData>()
            {
                new() { Id = 0, Content = "Comment 1" },
                new() { Id = 1, Content = "Comment 2" },
                new() { Id = 2, Content = "Comment 3" },
            },
            Articles = new ObservableCollection<ArticleData>()
            {
                new() { Id = 0, Title = "Article 1", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 1"},
                new() { Id = 1, Title = "Article 2", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 2"},
                new() { Id = 2, Title = "Article 3", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 3"},
            }
        },
        new()
        {
            Logo = "https://picsum.photos/200",
            Nickname = "geralt",
            Subscribers = 11411,
            Likes = 4355,
            Comments = new ObservableCollection<CommentData>()
            {
                new() { Id = 0, Content = "Comment 11" },
                new() { Id = 1, Content = "Comment 12" },
                new() { Id = 2, Content = "Comment 13" },
            },
            Articles = new ObservableCollection<ArticleData>()
            {
                new() { Id = 0, Title = "Article 1", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 1"},
                new() { Id = 1, Title = "Article 2", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 2"},
                new() { Id = 2, Title = "Article 3", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 3"},
            }
        },
        new()
        {
            Logo = "https://picsum.photos/100",
            Nickname = "lol",
            Subscribers = 1411,
            Likes = 435,
            Comments = new ObservableCollection<CommentData>()
            {
                new() { Id = 0, Content = "Comment 211" },
                new() { Id = 2, Content = "Comment 213" },
            },
            Articles = new ObservableCollection<ArticleData>()
            {
                new() { Id = 0, Title = "Article 1", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 1"},
                new() { Id = 1, Title = "Article 2", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 2"},
                new() { Id = 2, Title = "Article 3", Thumbnail="https://picsum.photos/200", Content = "Lorem ipsum 3"},
            }
        }
    };
}