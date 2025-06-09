using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace VamaDesktop.Converters;

public class EqualityConverter : IValueConverter
{
    public static EqualityConverter Instance { get; } = new();
    
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value?.ToString() == parameter?.ToString();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}