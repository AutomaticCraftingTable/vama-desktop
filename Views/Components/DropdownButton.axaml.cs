using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using VamaDesktop.Models;

namespace VamaDesktop.Views.Components;

public partial class DropdownButton : UserControl
{
    public DropdownButton()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ObservableCollection<ButtonData>> ItemsProperty = AvaloniaProperty.Register<DropdownButton, ObservableCollection<ButtonData>>(
        nameof(Items));

    public ObservableCollection<ButtonData> Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
}