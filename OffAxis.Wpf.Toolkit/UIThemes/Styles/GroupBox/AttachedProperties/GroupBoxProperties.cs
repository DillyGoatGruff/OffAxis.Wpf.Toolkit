using System.Windows;

namespace OffAxis.Wpf.Toolkit.UIThemes.Styles.GroupBox.AttachedProperties
{
    /// <summary>
    /// Attached properties for GroupBox styling
    /// </summary>
    public static class GroupBoxProperties
    {
        /// <summary>
        /// Gets the inner border thickness from the dynamic resource
        /// </summary>
        public static Thickness GetInnerBorderThickness(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(InnerBorderThicknessProperty);
        }

        public static void SetInnerBorderThickness(DependencyObject obj, Thickness value)
        {
            obj.SetValue(InnerBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty InnerBorderThicknessProperty =
            DependencyProperty.RegisterAttached(
                "InnerBorderThickness",
                typeof(Thickness),
                typeof(GroupBoxProperties),
                new PropertyMetadata(new Thickness(1)));
    }
}
