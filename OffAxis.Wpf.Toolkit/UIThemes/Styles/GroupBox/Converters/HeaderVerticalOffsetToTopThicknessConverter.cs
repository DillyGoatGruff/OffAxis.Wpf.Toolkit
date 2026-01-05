using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OffAxis.Wpf.Toolkit.UIThemes.Styles.GroupBox.Converters
{
    internal class HeaderVerticalOffsetToTopThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Thickness margin)
            {
                // The header is vertically shifted down by the Top margin, so to offset that we need to move it up by that amount
                return new Thickness(0, -margin.Top, 0,0);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
