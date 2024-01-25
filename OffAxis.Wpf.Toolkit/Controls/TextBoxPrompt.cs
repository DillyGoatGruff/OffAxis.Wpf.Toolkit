using System.Windows;
using System.Windows.Controls;

namespace OffAxis.Wpf.Toolkit.Controls
{
    public class TextBoxPrompt : TextBox
    {
        #region Prompt

        // Using a DependencyProperty as the backing store for Prompt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromptProperty =
            DependencyProperty.Register(nameof(Prompt), typeof(string), typeof(TextBoxPrompt), new PropertyMetadata(""));

        public string Prompt
        {
            get { return (string)GetValue(PromptProperty); }
            set { SetValue(PromptProperty, value); }
        }

        #endregion

        #region PromptAlignment

        // Using a DependencyProperty as the backing store for PromptAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromptAlignmentProperty =
            DependencyProperty.Register(nameof(PromptAlignment), typeof(TextAlignment), typeof(TextBoxPrompt), new PropertyMetadata(TextAlignment.Left));

        public TextAlignment PromptAlignment
        {
            get { return (TextAlignment)GetValue(PromptAlignmentProperty); }
            set { SetValue(PromptAlignmentProperty, value); }
        }

        #endregion

        #region CornerRadius

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(TextBoxPrompt), new PropertyMetadata(new CornerRadius()));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion

        static TextBoxPrompt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxPrompt), new FrameworkPropertyMetadata(typeof(TextBoxPrompt)));
        }
    }
}
