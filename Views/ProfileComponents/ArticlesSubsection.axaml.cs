using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Views.ProfileComponents;

public partial class ArticlesSubsection : UserControl
{
    public ArticlesSubsection()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ObservableCollection<ArticleData>> ArticlesProperty =
        AvaloniaProperty.Register<ArticlesSubsection, ObservableCollection<ArticleData>>(nameof(Articles));

    public ObservableCollection<ArticleData> Articles
    {
        get => GetValue(ArticlesProperty);
        set => SetValue(ArticlesProperty, value);
    }
}