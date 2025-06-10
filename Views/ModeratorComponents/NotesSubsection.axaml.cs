using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using VamaDesktop.API.DTO.Base;

namespace VamaDesktop.Views.ModeratorComponents;

public partial class NotesSubsection : UserControl
{
    public NotesSubsection()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ObservableCollection<NoteData>> NotesProperty =
        AvaloniaProperty.Register<NotesSubsection, ObservableCollection<NoteData>>(nameof(Notes),
            defaultBindingMode: BindingMode.TwoWay);

    public ObservableCollection<NoteData> Notes
    {
        get => GetValue(NotesProperty);
        set => SetValue(NotesProperty, value);
    }
}