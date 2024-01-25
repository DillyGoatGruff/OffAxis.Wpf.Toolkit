using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OffAxis.Wpf.Toolkit.Controls.TextBoxPromptTools
{
    public class IsNullOrWhiteSpaceVisibilityConverter : IValueConverter
    {
        public Visibility NullOrWhiteSpaceValue { get; set; } = Visibility.Visible;
        public Visibility NotNullOrWhiteSpaceValue { get; set; } = Visibility.Hidden;


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string s) return value;

            return string.IsNullOrWhiteSpace(s) ? NullOrWhiteSpaceValue : NotNullOrWhiteSpaceValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
