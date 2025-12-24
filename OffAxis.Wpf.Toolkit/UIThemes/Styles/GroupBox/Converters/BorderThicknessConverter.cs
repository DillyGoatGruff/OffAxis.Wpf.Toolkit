using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OffAxis.Wpf.Toolkit.UIThemes.Styles.GroupBox.Converters
{
    internal class BorderThicknessConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null &&
               values.Length == 2 &&
               values[0] is Thickness borderThickness &&
               values[1] is Thickness innerBorderThickness)
            {
                return new Thickness(
                    borderThickness.Left * 2 + innerBorderThickness.Left,
                    borderThickness.Top * 2 + innerBorderThickness.Top,
                    borderThickness.Right * 2 + innerBorderThickness.Right,
                    borderThickness.Bottom * 2 + innerBorderThickness.Bottom);
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
