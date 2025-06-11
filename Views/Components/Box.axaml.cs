using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using VamaDesktop.Models;

namespace VamaDesktop.Views.Components;
public partial class Box : UserControl
{
    public Box() => InitializeComponent();

    public static readonly StyledProperty<ObservableCollection<ButtonData>> DropdownItemsProperty = AvaloniaProperty.Register<Box, ObservableCollection<ButtonData>>(
        nameof(DropdownItems));

    public ObservableCollection<ButtonData> DropdownItems
    {
        get => GetValue(DropdownItemsProperty);
        set => SetValue(DropdownItemsProperty, value);
    }

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<Box, string>(
        nameof(Text));

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly StyledProperty<string?> ImageUrlProperty = AvaloniaProperty.Register<Box, string?>(
        nameof(ImageUrl));

    public string? ImageUrl
    {
        get => GetValue(ImageUrlProperty);
        set => SetValue(ImageUrlProperty, value);
    }
}