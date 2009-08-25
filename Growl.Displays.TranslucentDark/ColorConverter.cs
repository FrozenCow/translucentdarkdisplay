using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Growl.Displays.TranslucentDark
{
    [ValueConversion(typeof(Color), typeof(Color), ParameterType = typeof(Color))]
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)System.Convert.ChangeType(value, typeof(Color));
            Color parameterColor;
            if (parameter is Color)
                parameterColor = (Color)parameter;
            else
            {
                var converter = new System.Windows.Media.ColorConverter();
                parameterColor = (Color)converter.ConvertFrom(parameter);
            }

            return Color.FromArgb(
                (byte)(color.A * parameterColor.A / 255),
                (byte)(color.R * parameterColor.R / 255),
                (byte)(color.G * parameterColor.G / 255),
                (byte)(color.B * parameterColor.B / 255)
                );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}