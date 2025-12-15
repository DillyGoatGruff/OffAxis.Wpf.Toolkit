using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace OffAxis.Wpf.Toolkit.Adorners
{
    /// <summary>
    /// Adds a Border around the adorned element
    /// </summary>
    public class BorderAdorner : Adorner
    {
        #region Adorner Implementation

        private readonly VisualCollection _visualCollection;
        private UIElement _adornerElement;

        /// <summary>
        /// Creates an instance of the BorderAdorner.
        /// </summary>
        /// <param name="adornedElement">The element that the adorner will border.</param>
        /// <param name="adornerElement">The adorner that going around the adorned element.</param>
        public BorderAdorner(UIElement adornedElement, UIElement adornerElement) : base(adornedElement)
        {
            _adornerElement = adornerElement;
            _visualCollection = new VisualCollection(this)
            {
                adornerElement
            };
        }
        protected override Visual GetVisualChild(int index)
        {
            return _visualCollection[index];
        }

        protected override int VisualChildrenCount => _visualCollection.Count;

        protected override Size MeasureOverride(Size constraint)
        {
            FrameworkElement? adornerElement = GetAdornment((FrameworkElement)AdornedElement);

            if (adornerElement is not null)
            {
                // To use this attached property, the adorner element needs to have a border control with the name "PART_border"
                Border b = (Border)adornerElement.FindName("PART_border");
                Size contentSize = ((FrameworkElement)AdornedElement).DesiredSize;  // This seems to work, but if there is a problem, may need to use ActualWidth and ActualHeight property

                Thickness borderPadding = GetBorderPadding(adornerElement);
                b.Width = contentSize.Width + b.BorderThickness.Left + b.BorderThickness.Right + borderPadding.Left + borderPadding.Right;
                b.Height = contentSize.Height + b.BorderThickness.Top + b.BorderThickness.Bottom + borderPadding.Top + borderPadding.Bottom;
                adornerElement.Measure(new Size(double.MaxValue, double.MaxValue));
                
                double width = contentSize.Width + b.BorderThickness.Left + b.BorderThickness.Right + +borderPadding.Left + borderPadding.Right;
                double height = adornerElement.DesiredSize.Height + b.BorderThickness.Top + b.BorderThickness.Bottom + borderPadding.Top + borderPadding.Bottom;
                
                return new Size(width, height);
            }

            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            FrameworkElement? adornerElement = GetAdornment((FrameworkElement)AdornedElement);

            if (adornerElement is not null)
            {
                // To use this attached property, the adorner element needs to have a border control with the name "PART_border"
                Border b = (Border)adornerElement.FindName("PART_border");
                Size contentSize = ((FrameworkElement)AdornedElement).DesiredSize;  // This seems to work, but if there is a problem, may need to use ActualWidth and ActualHeight property

                Thickness borderPadding = GetBorderPadding(adornerElement);
                double x = 0 - b.BorderThickness.Left - borderPadding.Left;
                double y = -(adornerElement.DesiredSize.Height - b.Height) - b.BorderThickness.Top - borderPadding.Top;

                Rect adornerElementSize = new Rect(x, y, finalSize.Width, finalSize.Height);
                adornerElement.Arrange(adornerElementSize);
                return adornerElementSize.Size;
            }

            return base.ArrangeOverride(finalSize); 
        }

        #endregion

        #region Adornment

        // Using a DependencyProperty as the backing store for Adornerment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdornmentProperty =
            DependencyProperty.RegisterAttached("Adornment", typeof(FrameworkElement), typeof(BorderAdorner), new PropertyMetadata(null, OnAdornermentChanged));

        public static FrameworkElement? GetAdornment(FrameworkElement obj)
        {
            return (FrameworkElement?)obj.GetValue(AdornmentProperty);
        }

        public static void SetAdornment(FrameworkElement obj, FrameworkElement? value)
        {
            obj.SetValue(AdornmentProperty, value);
        }


        private static void OnAdornermentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is FrameworkElement adornedElement)
            {
                FrameworkElement adornerElement = (FrameworkElement)e.NewValue;
                adornedElement.MouseEnter += AdornedElement_MouseEnter;
                adornedElement.MouseLeave += AdornedElement_MouseLeave;

                if (GetAssignAdornmentDataContextToAdornedElement(d))
                {
                    //System.Windows.Data.Binding binding = new System.Windows.Data.Binding()
                    //{
                    //    Source = adornedElement,
                    //    Path = new PropertyPath("DataContext"),
                    //    Mode = System.Windows.Data.BindingMode.OneWay,
                    //    UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    //};
                    //adornerElement.SetBinding(DataContextProperty, binding);
                    adornerElement.DataContext = adornedElement;
                }
            }
        }

        #endregion

        #region AssignAdornmentDataContextToAdornedElement

        // Using a DependencyProperty as the backing store for AssignAdornmentDataContextToAdornedElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssignAdornmentDataContextToAdornedElementProperty =
            DependencyProperty.RegisterAttached("SyncAdornmentDataContextToAdornedElement", typeof(bool), typeof(BorderAdorner), new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.NotDataBindable, AssignAdornmentDataContextToAdornedElementChanged));

        public static bool GetAssignAdornmentDataContextToAdornedElement(DependencyObject obj)
        {
            return (bool)obj.GetValue(AssignAdornmentDataContextToAdornedElementProperty);
        }

        public static void SetAssignAdornmentDataContextToAdornedElement(DependencyObject obj, bool value)
        {
            obj.SetValue(AssignAdornmentDataContextToAdornedElementProperty, value);
        }

        private static void AssignAdornmentDataContextToAdornedElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement adornedElement = (FrameworkElement)d;
            FrameworkElement? adornerElement = GetAdornment(adornedElement);
            if (adornerElement is not null && e.NewValue is bool b && b == true)
            {
                adornerElement.DataContext = adornedElement;
            }
        }

        #endregion

        #region BorderCornerRadius

        // Using a DependencyProperty as the backing store for BorderCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderCornerRadiusProperty =
            DependencyProperty.RegisterAttached("BorderCornerRadius", typeof(CornerRadius), typeof(BorderAdorner), new PropertyMetadata(new CornerRadius(5), OnBorderCornerRadiusChanged));

        public static CornerRadius GetBorderCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(BorderCornerRadiusProperty);
        }

        public static void SetBorderCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(BorderCornerRadiusProperty, value);
        }

        private static void OnBorderCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement adornerElement)
            {
                Border b = (Border)adornerElement.FindName("PART_border");
                b.CornerRadius = (CornerRadius)e.NewValue;
            }

        }

        #endregion

        #region BorderPadding

        // Using a DependencyProperty as the backing store for BorderPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderPaddingProperty =
            DependencyProperty.RegisterAttached("BorderPadding", typeof(Thickness), typeof(BorderAdorner), new PropertyMetadata(new Thickness(0)));

        public static Thickness GetBorderPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(BorderPaddingProperty);
        }

        public static void SetBorderPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(BorderPaddingProperty, value);
        }

        #endregion

        private static void AdornedElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is FrameworkElement adornedElement)
            {
                AdornerLayer adornerLayer = GetAdornerLayer(adornedElement);
                Adorner? adorner = GetAdornerInLayer(adornerLayer, adornedElement);

                // If adornerHelper is not null, then the adorner has already been added to the AdornerLayer and should not be added again
                if (adorner is null && GetAdornment(adornedElement) is FrameworkElement adornerElement)
                {
                    adornerLayer.Add(new BorderAdorner(adornedElement, adornerElement));
                }
            }
        }

        private static void AdornedElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is FrameworkElement adornedElement)
            {
                AdornerLayer adornerLayer = GetAdornerLayer(adornedElement);
                BorderAdorner borderAdornment = adornerLayer.GetAdorners(adornedElement).OfType<BorderAdorner>().First();

                // If the mouse has left the AdornedElement but is now over the AdornerElement, then the adorner should still remain
                if (!borderAdornment._adornerElement.IsMouseOver)
                {
                    borderAdornment.MouseLeave -= _adornerElement_MouseLeave;
                    adornerLayer.Remove(borderAdornment);
                    borderAdornment._visualCollection.Remove(borderAdornment._adornerElement);
                }
                else
                {
                    borderAdornment.MouseLeave += _adornerElement_MouseLeave;
                }
            }

        }

        private static void _adornerElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is BorderAdorner borderAdornment)
            {
                AdornerLayer adornerLayer = GetAdornerLayer(borderAdornment.AdornedElement);

                if (!borderAdornment.AdornedElement.IsMouseOver)
                {
                    borderAdornment.MouseLeave -= _adornerElement_MouseLeave;
                    adornerLayer.Remove(borderAdornment);
                    borderAdornment._visualCollection.Remove(borderAdornment._adornerElement);
                }

            }
        }

        private static AdornerLayer GetAdornerLayer(UIElement adornedElement)
        {
            //AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);
            Window wnd = Window.GetWindow(adornedElement);
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)wnd.Content); // Use the highest level adorner layer so there is no clipping in the display
            return adornerLayer;
        }

        private static Adorner? GetAdornerInLayer(AdornerLayer adornerLayer, UIElement adornedElement)
        {
            return adornerLayer.GetAdorners(adornedElement)?.FirstOrDefault();//FirstOrDefault(x => x is Adorner) as Adorner;
        }
    }
}
