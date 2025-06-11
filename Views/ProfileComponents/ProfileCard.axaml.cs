using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.API.Utils;
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
            Text = "Podnieś rolę do moderatora",
            Click = new RelayCommand(() =>
            {
                if (Data.AccountId is not { } id) return;

                var r = TheoryRequests.ChangeRole(
                    id,
                    new Dictionary<string, string> { { "role", "moderator" } }
                ).AsyncInvoke();
            })
        },
        new()
        {
            Text = "Zablokuj konto",
            Click = new RelayCommand(() =>
            {
                if (Data.AccountId is not { } id) return;

                var r = TheoryRequests.BanAccount(id).AsyncInvoke();
            })
        },
        new()
        {
            Text = "Usuń konto",
            Click = new RelayCommand(() =>
            {
                if (Data.AccountId is not { } id) return;

                var r = TheoryRequests.DeleteAccount(id);
                r.Actions.OnSuccess += _ => Content = null;
                _ = r.AsyncInvoke();
            })
        }
    };

    private void TabSwitched(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tabControl) return;

        SectionId = tabControl.SelectedIndex;
    }
}