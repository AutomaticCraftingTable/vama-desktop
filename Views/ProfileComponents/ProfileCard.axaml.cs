using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.Models;

namespace VamaDesktop.Views.ProfileComponents;

public partial class ProfileCard : UserControl
{
    public ProfileCard()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ProfileCardData> DataProperty =
        AvaloniaProperty.Register<ProfileCard, ProfileCardData>(
            nameof(Data));

    public ProfileCardData Data
    {
        get => GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    public static readonly StyledProperty<int> IdProperty = AvaloniaProperty.Register<ProfileCard, int>(
        nameof(Id));

    public int Id
    {
        get => GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public static readonly StyledProperty<int> SectionIdProperty = AvaloniaProperty.Register<ProfileCard, int>(
        nameof(SectionId));

    public int SectionId
    {
        get => GetValue(SectionIdProperty);
        set => SetValue(SectionIdProperty, value);
    }
    
    public ObservableCollection<ButtonData> DropdownItems => new()
    {
        new()
        {
            Text = "Zgłoś profil",
            Click = new RelayCommand(() => Console.WriteLine($"Zgłoś komentarz: {Id}"))
        },
        new()
        {
            Text = "Zablokuj profil",
            Click = new RelayCommand(() => Console.WriteLine($"Zablokuj komentarz: {Id}"))
        },
        new()
        {
            Text = "Usuń profil",
            Click = new RelayCommand(() => Console.WriteLine($"Zablokuj komentarz: {Id}"))
        }
    };

    private void TabSwitched(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tabControl) return;
        
        SectionId = tabControl.SelectedIndex;
    }
}