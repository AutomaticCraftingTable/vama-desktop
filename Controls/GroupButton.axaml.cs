using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace VamaDesktop.Controls;

public class GroupButton : Button
{
    public static readonly StyledProperty<bool> IsSelectedProperty = AvaloniaProperty.Register<GroupButton, bool>(
        nameof(IsSelected));

    public bool IsSelected
    {
        get => GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }
    protected override void OnClick()
    {
        base.OnClick();
    }
}