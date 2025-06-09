using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.Models;

namespace VamaDesktop.Views.ProfileComponents;

public partial class CommentComponent : UserControl
{
    public static readonly StyledProperty<int> IdProperty = AvaloniaProperty.Register<CommentComponent, int>(
        nameof(Id));

    public int Id
    {
        get => GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<CommentComponent, string>(
        nameof(Text));

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public CommentComponent()
    {
        InitializeComponent();
    }

    public ObservableCollection<ButtonData> DropdownItems => new()
    {
        new()
        {
            Text = "Zgłoś komentarz",
            Click = new RelayCommand(() => Console.WriteLine($"Zgłoś komentarz: {Id}"))
        },
        new()
        {
            Text = "Zablokuj komentarz",
            Click = new RelayCommand(() => Console.WriteLine($"Zablokuj komentarz: {Id}"))
        }
    };
}