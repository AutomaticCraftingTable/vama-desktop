using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data.Converters;

namespace VamaDesktop.Controls;


public class BoolToThicknessConverter : IValueConverter
{
    public static readonly BoolToThicknessConverter Instance = new();

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is true 
            ? new Thickness(2)  
            : new Thickness(0);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

public class ErrorWrapper : ContentControl
{
    public static readonly StyledProperty<string> MessageProperty = AvaloniaProperty.Register<ErrorWrapper, string>(
        nameof(Message), string.Empty);

    public string Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
    
    public static readonly StyledProperty<bool> IsErrorVisibleProperty =
        AvaloniaProperty.Register<ErrorWrapper, bool>(nameof(IsErrorVisible));

    public bool IsErrorVisible
    {
        get => GetValue(IsErrorVisibleProperty);
        private set => SetValue(IsErrorVisibleProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == MessageProperty)
        {
            IsErrorVisible = !string.IsNullOrEmpty(change.GetNewValue<string>());
        }
    }
}