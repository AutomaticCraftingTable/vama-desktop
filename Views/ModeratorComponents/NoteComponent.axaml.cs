using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using VamaDesktop.API.DTO.Base;
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
            Click = new RelayCommand(() => Console.WriteLine($"Zgłoś komentarz: {Note.Id}"))
        }
    };
}