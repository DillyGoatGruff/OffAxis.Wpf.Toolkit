using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace OffAxis.Wpf.Toolkit.AttachedProperties
{
    public class WindowHelper : DependencyObject
	{

		#region ActAsTitleBarProperty

		private static Dictionary<UIElement, (int X, int Y)> MouseDownLocationDictionary = new Dictionary<UIElement, (int X, int Y)>();

		public static readonly DependencyProperty ActAsTitleBarProperty =
			DependencyProperty.RegisterAttached("ActAsTitleBar", typeof(bool), typeof(WindowHelper), new UIPropertyMetadata(false, new PropertyChangedCallback(OnActAsTitleBarChanged)));

		private static void Element_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (sender is UIElement element)
			{
				element.MouseMove -= Element_MouseMove;
			}
		}

		//[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
		//private static extern void ReleaseCapture();

		//[System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
		//private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private static void Element_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (sender is UIElement element)
			{
				//Window wnd = Window.GetWindow(element);
				//ReleaseCapture();
				//SendMessage(new WindowInteropHelper(wnd).Handle, 0x112, 0xf012, 0);

				//return;

				element.PreviewMouseLeftButtonUp += Element_MouseLeftButtonUp;
				element.MouseMove += Element_MouseMove;


			}
		}

		private static void Element_MouseMove(object sender, MouseEventArgs e)
		{
			if (sender is UIElement element && e.LeftButton == MouseButtonState.Pressed)
			{
				Window wnd = Window.GetWindow(element);

				if (wnd.WindowState != WindowState.Maximized)
				{
					wnd.WindowState = WindowState.Normal;
					wnd.DragMove();
					element.MouseMove -= Element_MouseMove;
				}
			}
		}

		public static bool GetActAsTitleBar(UIElement element)
		{

			return (bool)element.GetValue(ActAsTitleBarProperty);
		}

		public static void SetActAsTitleBar(UIElement element, bool value)
		{
			element.SetValue(ActAsTitleBarProperty, value);
		}

		private static void OnActAsTitleBarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is UIElement element)
			{
				if ((bool)e.NewValue == false)
					element.MouseLeftButtonDown -= Element_MouseLeftButtonDown;
				else
				{
					element.MouseLeftButtonDown += Element_MouseLeftButtonDown;
					element.MouseLeftButtonDown -= mouseDoubleClickElement_MouseLeftButtonDown;
					if (GetAllowDoubleClickToMaximize(element))
						element.MouseLeftButtonDown += mouseDoubleClickElement_MouseLeftButtonDown;
				}
			}
		}

		private static void RegisterActAsTitleBarListeners(UIElement element)
		{
			element.MouseLeftButtonDown += Element_MouseLeftButtonDown;

		}

		#endregion

		#region AllowDoubleClickToMaximize

		public static bool GetAllowDoubleClickToMaximize(DependencyObject obj)
		{
			return (bool)obj.GetValue(AllowDoubleClickToMaximizeProperty);
		}

		public static void SetAllowDoubleClickToMaximize(DependencyObject obj, bool value)
		{
			obj.SetValue(AllowDoubleClickToMaximizeProperty, value);
		}

		// Using a DependencyProperty as the backing store for AllowDoubleClickToMaximize.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AllowDoubleClickToMaximizeProperty =
			DependencyProperty.RegisterAttached("AllowDoubleClickToMaximize", typeof(bool), typeof(WindowHelper), new FrameworkPropertyMetadata(true, OnAllowDoubleClickToMaximizeChanged));

		private static void OnAllowDoubleClickToMaximizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is UIElement element)
			{
				element.MouseLeftButtonDown -= mouseDoubleClickElement_MouseLeftButtonDown;

				if ((bool)e.NewValue)
					element.MouseLeftButtonDown += mouseDoubleClickElement_MouseLeftButtonDown;
			}
		}

		private static void mouseDoubleClickElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (sender is UIElement element)
			{
				if (e.ClickCount > 1 && GetActAsTitleBar(element))
				{
					Window wnd = Window.GetWindow(element);
					wnd.WindowState = (wnd.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
				}

			}
		}



		#endregion

		#region ActAsCloseButton

		public static bool GetActAsCloseButton(ButtonBase obj)
		{
			return (bool)obj.GetValue(ActAsCloseButtonProperty);
		}

		public static void SetActAsCloseButton(ButtonBase obj, bool value)
		{
			obj.SetValue(ActAsCloseButtonProperty, value);
		}

		// Using a DependencyProperty as the backing store for ActAsCloseButton.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ActAsCloseButtonProperty =
			DependencyProperty.RegisterAttached("ActAsCloseButton", typeof(bool), typeof(WindowHelper), new FrameworkPropertyMetadata(false, OnActAsCloseButtonChanged));

		private static void OnActAsCloseButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ButtonBase button)
			{
				button.Click -= Button_Click;
				if (GetActAsCloseButton(button))
					button.Click += Button_Click;
			}
		}

		private static void Button_Click(object sender, RoutedEventArgs e)
		{
			if (sender is ButtonBase button)
			{
				Window w = Window.GetWindow(button);
				w.Close();
			}
				
		}



		#endregion

		#region ActiveControl

		// Using a DependencyProperty as the backing store for FocusedControl.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty FocusedControlProperty =
			DependencyProperty.RegisterAttached("FocusedControl", typeof(Control), typeof(WindowHelper), new PropertyMetadata(null, OnFocusedControlPropertyChanged));

		public static Control? GetFocusedControl(Window obj)
		{
			return (Control?)obj.GetValue(FocusedControlProperty);
		}

		public static void SetFocusedControl(Window obj, Control? value)
		{
			obj.SetValue(FocusedControlProperty, value);
		}


		private static void OnFocusedControlPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if(d is Window focusedControlWindow)
			{
				focusedControlWindow.Loaded -= FocusedControlWindow_Loaded;
				focusedControlWindow.Loaded += FocusedControlWindow_Loaded;
			}
		}

		private static void FocusedControlWindow_Loaded(object sender, RoutedEventArgs e)
		{
			Window focusedControlWindow = (Window)sender;
			focusedControlWindow.Unloaded -= FocusedControlWindow_Unloaded;
			focusedControlWindow.Unloaded += FocusedControlWindow_Unloaded;

			Control? control = GetFocusedControl(focusedControlWindow);
			control?.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
		}

		private static void FocusedControlWindow_Unloaded(object sender, RoutedEventArgs e)
		{
			Window focusedControlWindow = (Window)sender;
			focusedControlWindow.Loaded -= FocusedControlWindow_Loaded;
			focusedControlWindow.Unloaded -= FocusedControlWindow_Unloaded;
		}

		#endregion
	}
}
