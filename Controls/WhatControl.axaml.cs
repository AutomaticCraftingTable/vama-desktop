using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace VamaDesktop.Controls;

public class WhatControl : TemplatedControl
{
    public static readonly StyledProperty<string> SomeProperty = AvaloniaProperty.Register<WhatControl, string>(
        nameof(Some), defaultValue: "Huh");

    public string Some
    {
        get => GetValue(SomeProperty);
        set => SetValue(SomeProperty, value);
    }
}