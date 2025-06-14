using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using Material.Styles.Controls;
using Material.Styles.Models;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;

namespace VamaDesktop.Views.ModeratorComponents;

public partial class NoteComponent : UserControl
{
    public NoteComponent()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<NoteData> NoteProperty = AvaloniaProperty.Register<NoteComponent, NoteData>(
        nameof(Note));

    public NoteData Note
    {
        get => GetValue(NoteProperty);
        set => SetValue(NoteProperty, value);
    }

    public ObservableCollection<ButtonData> DropdownItems => new()
    {
        new()
        {
            Text = "Usuń notatkę",
            Click = new RelayCommand(
                () =>
                {
                    if (Note.Id is not { } id) return;
                    _ = Requests.DeleteNote(id).AsyncInvoke();
                }
            )
        }
    };
}