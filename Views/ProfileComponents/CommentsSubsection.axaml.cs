using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Views.ProfileComponents;

public partial class CommentsSubsection : UserControl
{
    public CommentsSubsection()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ObservableCollection<CommentData>> CommentsProperty =
        AvaloniaProperty.Register<CommentsSubsection, ObservableCollection<CommentData>>(nameof(Comments),
            defaultBindingMode: BindingMode.TwoWay);

    public ObservableCollection<CommentData> Comments
    {
        get => GetValue(CommentsProperty);
        set => SetValue(CommentsProperty, value);
    }
}