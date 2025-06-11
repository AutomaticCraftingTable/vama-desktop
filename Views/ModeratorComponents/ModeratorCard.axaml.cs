using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;
using VamaDesktop.Models.Get;

namespace VamaDesktop.Views.ModeratorComponents;

public partial class ModeratorCard : UserControl
{
    public ModeratorCard()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ModeratorData> ModeratorProperty =
        AvaloniaProperty.Register<ModeratorCard, ModeratorData>(
            nameof(Moderator));

    public ModeratorData Moderator
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
                if (Moderator.Id is not { } id) return;

                var r = Requests.ChangeRole(
                    id,
                    new Dictionary<string, string> { { "role", "user" } }
                );
                r.Actions.OnSuccess += _ => Content = null;
                r.AsyncInvoke();
            })
        },
        new()
        {
            Text = "Usuń konto",
            Click = new RelayCommand(() =>
            {
                if (Moderator.Id is not { } id) return;

                var r = Requests.DeleteAccount(id);
                r.Actions.OnSuccess += _ => Content = null;
                _ = r.AsyncInvoke();
            })
        }
    };
}