using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace OffAxis.Wpf.Toolkit.Adorners
{
    public class OverlayAdorner : Adorner
    {
        #region Adorner Implementation

        private readonly VisualCollection _visualCollection;
        private UIElement _adornerElement;

        public OverlayAdorner(UIElement adornedElement, UIElement adornerElement) : base(adornedElement)
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
                Size contentSize = ((FrameworkElement)AdornedElement).DesiredSize;  // This seems to work, but if there is a problem, may need to use ActualWidth and ActualHeight property
                adornerElement.Measure(new Size(double.MaxValue, double.MaxValue));


                return adornerElement.DesiredSize; //new Size(width, height);
            }

            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            FrameworkElement? adornerElement = GetAdornment((FrameworkElement)AdornedElement);

            if (adornerElement is not null)
            {
                var subElement = GetElementToCenter(adornerElement);
                Size contentSize = AdornedElement.DesiredSize;  // This seems to work, but if there is a problem, may need to use ActualWidth and ActualHeight property
                Size adornerElementPositioningSize = finalSize;
                if(subElement is not null) adornerElementPositioningSize = subElement.DesiredSize;

                double x = (contentSize.Width - adornerElementPositioningSize.Width) / 2;
                double y = (contentSize.Height - adornerElementPositioningSize.Height) / 2;

                //The below code is to ensure the adorner element stays within the bounds of the adorner layer.
                AdornerLayer? adornerLayer = GetAdornerLayer(AdornedElement);
                if (adornerLayer is not null)
                {

                    PresentationSource source = PresentationSource.FromVisual(this);
                    double dpiXScaling = 1;
                    double dpiYScaling = 1;
                    if (source is not null)
                    {
                        dpiXScaling = source.CompositionTarget.TransformToDevice.M11;
                        dpiYScaling = source.CompositionTarget.TransformToDevice.M22;
                    }

                    Point adornerLayerPoint = adornerLayer.PointToScreen(new Point()); // Upper left corner of adorner layer
                    Point adornorElementPoint = AdornedElement.PointToScreen(new Point(x, y)); // Upper left corner of adorner element

                    // Need to correct for any DPI scaling on this monitor.
                    // The X locations have to be corrected for DPI scaling, but width does not
                    double shiftRight = Math.Max(0, adornerLayerPoint.X - adornorElementPoint.X);
                    if (shiftRight != 0)
                    {
                        x += shiftRight / dpiXScaling;
                    }
                    else
                    {
                        double shiftLeft = Math.Max(0, (adornorElementPoint.X / dpiXScaling + finalSize.Width) - (adornerLayerPoint.X / dpiXScaling + adornerLayer.ActualWidth));
                        if (shiftLeft != 0)
                        {
                            x -= shiftLeft;
                        }
                    }

                    // The Y locations have to be corrected for DPI scaling, but height does not
                    double shiftDown = Math.Max(0, adornerLayerPoint.Y - adornorElementPoint.Y);
                    if (shiftDown != 0)
                    {
                        y += shiftDown / dpiYScaling;
                    }
                    else
                    {
                        double shiftUp = Math.Max(0, (adornorElementPoint.Y / dpiYScaling + finalSize.Height) - (adornerLayerPoint.Y / dpiYScaling + adornerLayer.ActualHeight));
                        if (shiftUp != 0)
                        {
                            y -= shiftUp;
                        }
                    }
                }


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
            DependencyProperty.RegisterAttached("Adornment", typeof(FrameworkElement), typeof(OverlayAdorner), new PropertyMetadata(null, OnAdornermentChanged));

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
                    adornerElement.DataContext = adornedElement;
                }
            }
        }

        #endregion

        #region AssignAdornmentDataContextToAdornedElement

        // Using a DependencyProperty as the backing store for AssignAdornmentDataContextToAdornedElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssignAdornmentDataContextToAdornedElementProperty =
            DependencyProperty.RegisterAttached("AssignAdornmentDataContextToAdornedElement", typeof(bool), typeof(OverlayAdorner), new FrameworkPropertyMetadata(false,
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
            if (d is not FrameworkElement adornedElement)
            {
                return;
            }

            FrameworkElement? adornerElement = GetAdornment(adornedElement);

            // If Adornment is already set, apply the DataContext assignment
            if (adornerElement is not null 
                && e.NewValue is bool assignDataContext 
                && assignDataContext)
            {
                adornerElement.DataContext = adornedElement;
            }
        }

        #endregion

        #region ElementToCenter

        // When ArrangeOverride is called to position the adorner element, if this property is attached
        // to the ADORNMENT element (through the use of BindingProxy) then this sub element will be used to position the adorner element
        public static readonly DependencyProperty ElementToCenterProperty =
            DependencyProperty.RegisterAttached("ElementToCenter", typeof(UIElement), typeof(OverlayAdorner), new PropertyMetadata(null));

        public static UIElement? GetElementToCenter(DependencyObject obj)
        {
            return (UIElement?)obj.GetValue(ElementToCenterProperty);
        }

        public static void SetElementToCenter(DependencyObject obj, UIElement? value)
        {
            obj.SetValue(ElementToCenterProperty, value);
        }

        #endregion

        private static void AdornedElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is FrameworkElement adornedElement)
            {
                AdornerLayer? adornerLayer = GetAdornerLayer(adornedElement);
                if (adornerLayer is null) return;

                Adorner? adorner = GetAdornerInLayer(adornerLayer, adornedElement);

                // If adornerHelper is not null, then the adorner has already been added to the AdornerLayer and should not be added again
                if (adorner is null && GetAdornment(adornedElement) is FrameworkElement adornerElement)
                {
                    adornerLayer.Add(new OverlayAdorner(adornedElement, adornerElement));
                }
            }
        }

        private static void AdornedElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is FrameworkElement adornedElement)
            {
                AdornerLayer? adornerLayer = GetAdornerLayer(adornedElement);
                if (adornerLayer is null) return;

                OverlayAdorner? overlayAdornment = adornerLayer.GetAdorners(adornedElement)?.FirstOrDefault(x => x is OverlayAdorner) as OverlayAdorner;//.OfType<OverlayAdorner>().First();

                //During hot reloads this can be null sometimes
                if (overlayAdornment is not null)
                {
                    // If the mouse has left the AdornedElement but is now over the AdornerElement, then the adorner should still remain
                    if (!overlayAdornment._adornerElement.IsMouseOver)
                    {
                        overlayAdornment.MouseLeave -= _adornerElement_MouseLeave;
                        adornerLayer.Remove(overlayAdornment);
                        overlayAdornment._visualCollection.Remove(overlayAdornment._adornerElement);
                    }
                    else
                    {
                        overlayAdornment.MouseLeave += _adornerElement_MouseLeave;
                    }
                }
            }

        }

        private static void _adornerElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is OverlayAdorner overlayAdornment)
            {
                AdornerLayer? adornerLayer = GetAdornerLayer(overlayAdornment.AdornedElement);

                if (adornerLayer is null) return;
                else if (!overlayAdornment.AdornedElement.IsMouseOver)
                {
                    overlayAdornment.MouseLeave -= _adornerElement_MouseLeave;
                    adornerLayer.Remove(overlayAdornment);
                    overlayAdornment._visualCollection.Remove(overlayAdornment._adornerElement);
                }

            }
        }

        private static AdornerLayer? GetAdornerLayer(UIElement adornedElement)
        {
            //AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);
            Window? wnd = Window.GetWindow(adornedElement);
            if (wnd is null) return null;

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)wnd.Content); // Use the highest level adorner layer so there is no clipping in the display
            return adornerLayer;
        }

        private static Adorner? GetAdornerInLayer(AdornerLayer adornerLayer, UIElement adornedElement)
        {
            return adornerLayer.GetAdorners(adornedElement)?.FirstOrDefault();//FirstOrDefault(x => x is Adorner) as Adorner;
        }
    }
}
