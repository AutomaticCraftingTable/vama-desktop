using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;

namespace VamaDesktop.Views.ProfileComponents;

public partial class ArticleComponent : UserControl
{
    public ArticleComponent()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ArticleData> ArticleProperty =
        AvaloniaProperty.Register<ArticleComponent, ArticleData>(
            nameof(Article));

    public ArticleData Article
    {
        get => GetValue(ArticleProperty);
        set => SetValue(ArticleProperty, value);
    }

    public ObservableCollection<ButtonData> DropdownItems => new()
    {
        new()
        {
            Text = "Zgłoś artykuł",
            Click = new RelayCommand(() => _ = TheoryRequests.ReportArticle(Article.Id).AsyncInvoke())
        },
        new()
        {
            Text = "Zablokuj artykuł",
            Click = new RelayCommand(() => _ = TheoryRequests.BanArticle(Article.Id).AsyncInvoke())
        }
    };
}