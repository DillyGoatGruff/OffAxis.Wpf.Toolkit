using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OffAxis.Wpf.Toolkit.UIThemes.Styles.GroupBox.Converters
{
    internal class HeaderVerticalOffsetConverter : IMultiValueConverter
    {
        public object Convert(object?[]? values, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2)
            {
                return DependencyProperty.UnsetValue;
            }

            if (TryGetDoubleFromObject(values[0], out double height) && values[1] is Thickness innerBorderThickness)
            {
                return new Thickness(0, -height / 2 + innerBorderThickness.Top / 2, 0, 0);
            }

            return DependencyProperty.UnsetValue;
        }

        public bool TryGetDoubleFromObject(object? obj, out double dbl)
        {
            dbl = obj switch
            {
                double d => d,
                int i => i,
                decimal m => (double)m,
                float f => (double)f,
                string s when double.TryParse(s, out double parsed) => parsed,
                _ => double.NaN
            };

            return !double.IsNaN(dbl);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
