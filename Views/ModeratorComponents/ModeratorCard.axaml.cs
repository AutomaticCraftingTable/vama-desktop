using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;

namespace VamaDesktop.Views.ModeratorComponents;

public partial class ModeratorCard : UserControl
{
    public ModeratorCard()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ModeratorCardData> ModeratorProperty =
        AvaloniaProperty.Register<ModeratorCard, ModeratorCardData>(
            nameof(Moderator));

    public ModeratorCardData Moderator
    {
        get => GetValue(ModeratorProperty);
        set => SetValue(ModeratorProperty, value);
    }

    public ObservableCollection<ButtonData> DropdownItems => new()
    {
        new()
        {
            Text = "Obniż rolę do użytkownika",
            Click = new RelayCommand(() =>
            {
                if (Moderator.AccountId is not { } id) return;

                var r = TheoryRequests.ChangeRole(
                    id,
                    new Dictionary<string, string> { { "role", "user" } }
                ).AsyncInvoke();
            })
        },
        new()
        {
            Text = "Usuń konto",
            Click = new RelayCommand(() =>
            {
                if (Moderator.AccountId is not { } id) return;

                var r = TheoryRequests.DeleteAccount(id);
                r.Actions.OnSuccess += _ => Content = null;
                _ = r.AsyncInvoke();
            })
        }
    };
}