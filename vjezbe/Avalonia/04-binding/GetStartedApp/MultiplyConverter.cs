using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GetStartedApp;

public class MultiplyConverter : IValueConverter
{
    public double Factor { get; set; } = 1;
    public object? Convert(object? value, Type targetType, object? parameter,
        CultureInfo culture)
    {
        if (value is double d)
            return (d * Factor).ToString("0.##", culture);
        return value?.ToString();
    }
    public object? ConvertBack(object? value, Type targetType, object? parameter,
        CultureInfo culture)
    {
        if (value is string s && double.TryParse(s, NumberStyles.Any, culture, out var d))
            return d / Factor;
        return value;
    }
}