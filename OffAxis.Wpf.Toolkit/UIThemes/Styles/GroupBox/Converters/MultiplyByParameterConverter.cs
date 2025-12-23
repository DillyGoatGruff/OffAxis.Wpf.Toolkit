using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OffAxis.Wpf.Toolkit.UIThemes.Styles.GroupBox.Converters
{
    internal class MultiplyByParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If value is a Thickness, extract the Top value
            if (value is Thickness thickness)
                value = thickness.Top;

            if (TryGetDoubleFromObject(value, out double dValue) && TryGetDoubleFromObject(parameter, out double dParam))
            {
                return dValue * dParam;
            }

            return DependencyProperty.UnsetValue;
        }

        public bool TryGetDoubleFromObject(object obj, out double dbl)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
