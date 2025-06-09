using System.Collections.Generic;
using System.Collections.ObjectModel;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Models;

public record ProfileCardData
{
    public string Nickname { get; init; }
    public string Description { get; init; }
    public string Logo { get; init; }
    public int Subscribers { get; init; }
    public int Likes { get; init; }
    
    public ObservableCollection<CommentData> Comments { get; init; }
    public ObservableCollection<ArticleData> Articles { get; init; }
}