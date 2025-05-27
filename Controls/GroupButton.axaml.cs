using System;
using Avalonia;
using Avalonia.Controls;

namespace VamaDesktop.Controls;

public class GroupButton : Button
{
    protected override void OnInitialized()
    {
        Classes.Add(Id == SelectionId ? "current" : "secondary");
    }

    public static readonly StyledProperty<int> IdProperty = AvaloniaProperty.Register<GroupButton, int>(nameof(Id));

    public int Id
    {
        get => GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public static readonly StyledProperty<int> SelectionIdProperty =
        AvaloniaProperty.Register<GroupButton, int>(nameof(SelectionId));

    public int SelectionId
    {
        get => GetValue(SelectionIdProperty);
        set => SetValue(SelectionIdProperty, value);
    }
}