using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace OffAxis.Wpf.Toolkit.AttachedProperties
{
    public class ButtonBaseHelper : DependencyObject
	{
		#region CornerRadius

		// Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonBaseHelper), new PropertyMetadata(new CornerRadius(), OnCornerRadiusChanged));

		public static CornerRadius GetCornerRadius(ButtonBase obj)
		{
			return (CornerRadius)obj.GetValue(CornerRadiusProperty);
		}

		public static void SetCornerRadius(ButtonBase obj, CornerRadius value)
		{
			obj.SetValue(CornerRadiusProperty, value);
		}

		private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is not ButtonBase bb)
				return;

			bb.Loaded -= Bb_Loaded;
			if (bb.Style is not null)
				UpdateStyle(bb, GetCornerRadius(bb));
			else
				bb.Loaded += Bb_Loaded;

		}

		private static void Bb_Loaded(object sender, RoutedEventArgs e)
		{
			if (sender is ButtonBase bb)
			{
				Style s = bb.Style;
				UpdateStyle(bb, GetCornerRadius(bb));
			}
		}

		private static void UpdateStyle(ButtonBase buttonBase, CornerRadius cornerRadius)
		{

			Style style = new Style(buttonBase.Style.TargetType, buttonBase.Style);
			style.Setters.Add(new Setter(Border.CornerRadiusProperty, cornerRadius));
			buttonBase.Style = style;
		}

		#endregion

		#region DialogResultValue

		// Using a DependencyProperty as the backing store for DialogResult.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DialogResultValueProperty =
			DependencyProperty.RegisterAttached("DialogResultValue", typeof(bool), typeof(ButtonBaseHelper), new PropertyMetadata(false, OnDialogResultValueChanged));

		public static bool GetDialogValueResult(ButtonBase obj)
		{
			return (bool)obj.GetValue(DialogResultValueProperty);
		}

		public static void SetDialogResult(ButtonBase obj, bool value)
		{
			obj.SetValue(DialogResultValueProperty, value);
		}

		private static void OnDialogResultValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is not ButtonBase bb) return;

			bb.Click += (s, e) =>
			{
				Window w = Window.GetWindow(bb);
				try
				{
					w.DialogResult = GetDialogValueResult(bb);
				}
				catch (InvalidOperationException)
				{
					//This occurs if the window is displayed using .Show() instead of .ShowDialog()
				}
			};
		}

		#endregion

	}
}
