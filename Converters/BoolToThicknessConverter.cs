using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace VamaDesktop.Converters;

public class BoolToThicknessConverter : IValueConverter
{
    public static BoolToThicknessConverter Instance { get; } = new();
    
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