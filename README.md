# OffAxis.Wpf.Toolkit - Theming Guide

This guide explains how to customize the appearance of OffAxis.Wpf.Toolkit components through its Color and Brush resource system.

## Overview

The theming system uses a two-layer approach:

1. **Colors.xaml** - Defines the base color values
2. **Brushes.xaml** - Wraps colors in `SolidColorBrush` resources that are used throughout component styles

This separation allows you to override colors dynamically while keeping brush names consistent across all component styles.

## Quick Reference

Want to customize your theme quickly? Here are the most common customizations:

| Goal | Resource to Override | Example |
|------|---------------------|---------|
| Change all button backgrounds | `Colors.Background.*` | See "Override Colors Directly" |
| Change text color | `Colors.Foreground.*` | See "Override Colors Directly" |
| Change border colors | `Colors.Border.*` | See "Override Colors Directly" |
| Make buttons more rounded | `Button.CornerRadius.*` | Set to `10` or higher |
| Change checkbox indicator color | `Colors.StateMark.*` | Set to desired color |
| Create entire custom theme | Create custom theme file | See "Option 5" |
| Change colors at runtime | `Application.Current.Resources` | See "Dynamic Runtime Theming" |
| Customize panel backgrounds | `Colors.PanelBackground.*` | See "Panel Colors" |
| Change input field styling | `Colors.InputBackground.*` and `Colors.InputForeground.*` | See "Input Field Colors" |
| Make GroupBox borders thicker | `GroupBox.InnerBorderThickness` | Set to `2` or higher |

## Color Resources

All color resources are defined in `UIThemes/Colors.xaml` and are organized into categories:

### Background Colors

Used for control backgrounds in different interaction states:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.Background.Static` | Normal state background | `#FF3B82F6` (Blue) |
| `Colors.Background.MouseOver` | Background when mouse hovers | `#FF60A5FA` (Light Blue) |
| `Colors.Background.Pressed` | Background when button is pressed | `#FF2563EB` (Dark Blue) |
| `Colors.Background.Checked` | Background when control is checked | `#FF4C24EB` (Purple) |
| `Colors.Background.CheckedMouseOver` | Background when checked and hovered | `#FF6128FF` (Bright Purple) |
| `Colors.Background.CheckedPressed` | Background when checked and pressed | `#FF4D20CC` (Dark Purple) |
| `Colors.Background.Disabled` | Background when control is disabled | `#FF4A5568` (Gray) |

### Foreground Colors

Used for text and content rendering:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.Foreground.Static` | Normal text color | `#FFE2E8F0` (Light Gray) |
| `Colors.Foreground.MouseOver` | Text color when hovered | `#FFF7FAFC` (White-ish) |
| `Colors.Foreground.Pressed` | Text color when pressed | `#FFFFFFFF` (White) |
| `Colors.Foreground.Checked` | Text color when checked | `#FFFFFFFF` (White) |
| `Colors.Foreground.CheckedMouseOver` | Text color when checked and hovered | `#FFF7FAFC` (White-ish) |
| `Colors.Foreground.CheckedPressed` | Text color when checked and pressed | `#FFFFFFFF` (White) |
| `Colors.Foreground.Disabled` | Text color when disabled | `#FF718096` (Medium Gray) |

### Border Colors

Used for control borders:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.Border.Static` | Normal border color | `#FF4A5568` (Gray) |
| `Colors.Border.MouseOver` | Border when hovering | `#FF64748B` (Light Gray) |
| `Colors.Border.Pressed` | Border when pressed | `#FF475569` (Gray) |
| `Colors.Border.Checked` | Border when checked | `#FF30147F` (Dark Purple) |
| `Colors.Border.CheckedMouseOver` | Border when checked and hovered | `#FF30147F` (Dark Purple) |
| `Colors.Border.CheckedPressed` | Border when checked and pressed | `#FF130732` (Very Dark Purple) |
| `Colors.Border.Disabled` | Border when disabled | `#FF374151` (Dark Gray) |

### Panel Colors

Used for container backgrounds and text in panels:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.PanelBackground.Primary` | Primary panel background | `#FF1A202C` (Dark) |
| `Colors.PanelBackground.Secondary` | Secondary panel background | `#FF2D3748` (Medium Dark) |
| `Colors.PanelForeground.Primary` | Primary panel text | `#FFE2E8F0` (Light Gray) |
| `Colors.PanelForeground.Secondary` | Secondary panel text | `#FF94A3B8` (Medium Gray) |

### Input Field Colors

Used for TextBox and similar input controls:

**Background:**
| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.InputBackground.Static` | Normal input background | `#FF2D3748` (Dark Gray) |
| `Colors.InputBackground.MouseOver` | Input background when hovered | `#FF374151` (Lighter Gray) |
| `Colors.InputBackground.Pressed` | Input background when active/pressed | `#FF1F2937` (Very Dark Gray) |
| `Colors.InputBackground.Checked` | Input background when checked | `#FF374151` (Lighter Gray) |
| `Colors.InputBackground.CheckedMouseOver` | Checked input on hover | `#FF3B4A5A` (Medium Gray) |
| `Colors.InputBackground.CheckedPressed` | Checked input when pressed | `#FF1F2937` (Very Dark Gray) |
| `Colors.InputBackground.Disabled` | Input background when disabled | `#FF1F2937` (Very Dark Gray) |

**Foreground:**
| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.InputForeground.Static` | Normal input text color | `#FFE2E8F0` (Light Gray) |
| `Colors.InputForeground.MouseOver` | Input text on hover | `#FFF7FAFC` (White-ish) |
| `Colors.InputForeground.Pressed` | Input text when pressed | `#FFF7FAFC` (White-ish) |
| `Colors.InputForeground.Checked` | Input text when checked | `#FFF7FAFC` (White-ish) |
| `Colors.InputForeground.CheckedMouseOver` | Checked input text on hover | `#FFFFFFFF` (White) |
| `Colors.InputForeground.PressedMouseOver` | Input text when pressed and hovered | `#FFFFFFFF` (White) |
| `Colors.InputForeground.Disabled` | Input text when disabled | `#FF6B7280` (Gray) |

### State Mark Colors

Used for CheckBox checkmarks and RadioButton fill indicators:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.StateMark.Checked` | Color of checkmark/indicator when checked | `#FFFBBF24` (Yellow) |
| `Colors.StateMark.CheckedMouseOver` | Checkmark color on hover | `#FFFCD34D` (Light Yellow) |
| `Colors.StateMark.CheckedPressed` | Checkmark color when pressed | `#FFF59E0B` (Orange) |
| `Colors.StateMark.Disabled` | Checkmark color when disabled | `#FF6B7280` (Gray) |

### ScrollBar Colors

Used for scroll bars and related components:

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Colors.ScrollBar.Track` | Background of scroll bar track | `#FF1F2937` (Dark Gray) |
| `Colors.ScrollBar.Thumb.Static` | Normal scroll thumb color | `#FF4A5568` (Gray) |
| `Colors.ScrollBar.Thumb.MouseOver` | Scroll thumb on hover | `#FF64748B` (Light Gray) |
| `Colors.ScrollBar.Thumb.Pressed` | Scroll thumb when dragged | `#FF374151` (Dark Gray) |
| `Colors.ScrollBar.Thumb.Disabled` | Scroll thumb when disabled | `#FF374151` (Dark Gray) |

## Brush Resources

All brush resources are defined in `UIThemes/Brushes.xaml`. Each brush is a `SolidColorBrush` that references a corresponding color resource using `{DynamicResource}` binding.

Brush naming mirrors the color structure:
- `Brushes.Background.*` ? `Colors.Background.*`
- `Brushes.Foreground.*` ? `Colors.Foreground.*`
- `Brushes.Border.*` ? `Colors.Border.*`
- `Brushes.PanelBackground.*` ? `Colors.PanelBackground.*`
- `Brushes.PanelForeground.*` ? `Colors.PanelForeground.*`
- `Brushes.InputBackground.*` ? `Colors.InputBackground.*`
- `Brushes.InputForeground.*` ? `Colors.InputForeground.*`
- `Brushes.StateMark.*` ? `Colors.StateMark.*`
- `Brushes.ScrollBar.*` ? `Colors.ScrollBar.*`

## CornerRadius Resources

Each component style defines corner radius resources for different states. Override these to change the border roundness of controls.

### Button CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `Button.CornerRadius.Static` | Normal button corner radius | `5` |
| `Button.CornerRadius.MouseOver` | Corner radius on hover | `5` |
| `Button.CornerRadius.Pressed` | Corner radius when pressed | `5` |
| `Button.CornerRadius.Disabled` | Corner radius when disabled | `5` |

### ToggleButton CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ToggleButton.CornerRadius.Static` | Normal toggle button corner radius | `3` |
| `ToggleButton.CornerRadius.MouseOver` | Corner radius on hover | `3` |
| `ToggleButton.CornerRadius.Pressed` | Corner radius when pressed | `3` |
| `ToggleButton.CornerRadius.Checked` | Corner radius when checked | `3` |
| `ToggleButton.CornerRadius.CheckedMouseOver` | Corner radius when checked and hovered | `3` |
| `ToggleButton.CornerRadius.CheckedPressed` | Corner radius when checked and pressed | `3` |
| `ToggleButton.CornerRadius.Disabled` | Corner radius when disabled | `3` |

### TextBox CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `TextBox.CornerRadius.Static` | Normal text box corner radius | `3` |
| `TextBox.CornerRadius.MouseOver` | Corner radius on hover | `3` |
| `TextBox.CornerRadius.Focused` | Corner radius when focused | `3` |
| `TextBox.CornerRadius.Disabled` | Corner radius when disabled | `3` |

### CheckBox CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `CheckBox.CornerRadius.Static` | Normal checkbox corner radius | `3` |
| `CheckBox.CornerRadius.MouseOver` | Corner radius on hover | `2.5` |
| `CheckBox.CornerRadius.Pressed` | Corner radius when pressed | `2.5` |
| `CheckBox.CornerRadius.Checked` | Corner radius when checked | `3` |
| `CheckBox.CornerRadius.CheckedMouseOver` | Corner radius when checked and hovered | `3` |
| `CheckBox.CornerRadius.CheckedPressed` | Corner radius when checked and pressed | `3` |
| `CheckBox.CornerRadius.Disabled` | Corner radius when disabled | `3` |

### RadioButton CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `RadioButton.CornerRadius.Static` | Normal radio button corner radius | `8` |
| `RadioButton.CornerRadius.MouseOver` | Corner radius on hover | `8` |
| `RadioButton.CornerRadius.Pressed` | Corner radius when pressed | `8` |
| `RadioButton.CornerRadius.Checked` | Corner radius when checked | `8` |
| `RadioButton.CornerRadius.CheckedMouseOver` | Corner radius when checked and hovered | `8` |
| `RadioButton.CornerRadius.CheckedPressed` | Corner radius when checked and pressed | `8` |
| `RadioButton.CornerRadius.Disabled` | Corner radius when disabled | `8` |

### ComboBox CornerRadius

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ComboBox.CornerRadius.Static` | Normal combo box corner radius | `3` |
| `ComboBox.CornerRadius.MouseOver` | Corner radius on hover | `3` |
| `ComboBox.CornerRadius.Pressed` | Corner radius when pressed | `3` |
| `ComboBox.CornerRadius.Disabled` | Corner radius when disabled | `3` |

## Thickness Resources

Some components define customizable thickness values for borders and spacing:

### GroupBox Thickness Resources

| Key | Usage | Default Value |
|-----|-------|----------------|
| `GroupBox.InnerBorderThickness` | Thickness of the inner border | `1` |

## GroupBox Styling Resources

GroupBox has additional customizable resources beyond the standard color palette:

| Key | Type | Usage | Default Value |
|-----|------|-------|----------------|
| `GroupBox.CornerRadius` | CornerRadius | Corner radius for the group box border | `5` |
| `GroupBox.InnerBorderBrush` | SolidColorBrush | Color of the inner border | `DarkSlateBlue` |
| `GroupBox.InnerBorderThickness` | Thickness | Thickness of the inner border | `1` |

## ComboBox-Specific Resources

ComboBox defines component-specific brush resources for the dropdown glyph and popup:

### ComboBox Glyph Brushes

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ComboBox.Brushes.Glyph.Static` | Dropdown arrow color in normal state | Inherits from `Colors.Foreground.Static` |
| `ComboBox.Brushes.Glyph.MouseOver` | Dropdown arrow color on hover | Inherits from `Colors.Foreground.MouseOver` |
| `ComboBox.Brushes.Glyph.Pressed` | Dropdown arrow color when pressed | Inherits from `Colors.Foreground.Pressed` |
| `ComboBox.Brushes.Glyph.Disabled` | Dropdown arrow color when disabled | Inherits from `Colors.Foreground.Disabled` |

### ComboBox Input Brushes

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ComboBox.Brushes.InputBackground.Static` | Input field background | Inherits from `Colors.InputBackground.Static` |
| `ComboBox.Brushes.InputBackground.MouseOver` | Input field background on hover | Inherits from `Colors.InputBackground.MouseOver` |
| `ComboBox.Brushes.InputBackground.Pressed` | Input field background when active | Inherits from `Colors.InputBackground.Pressed` |
| `ComboBox.Brushes.InputBackground.Disabled` | Input field background when disabled | Inherits from `Colors.InputBackground.Disabled` |

### ComboBox Border Brushes

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ComboBox.Brushes.Border.Static` | Border color in normal state | Inherits from `Colors.Border.Static` |
| `ComboBox.Brushes.Border.MouseOver` | Border color on hover | Inherits from `Colors.Border.MouseOver` |
| `ComboBox.Brushes.Border.Pressed` | Border color when active | Inherits from `Colors.Border.Pressed` |
| `ComboBox.Brushes.Border.Disabled` | Border color when disabled | Inherits from `Colors.Border.Disabled` |

### ComboBox Popup Brushes

| Key | Usage | Default Value |
|-----|-------|----------------|
| `ComboBox.Brushes.Popup.Background` | Dropdown popup background | Inherits from `Colors.PanelBackground.Secondary` |
| `ComboBox.Brushes.Popup.Foreground` | Dropdown popup text color | Inherits from `Colors.PanelForeground.Secondary` |

## All Overridable Resources

The following is a complete list of all resources that can be overridden to customize the toolkit's appearance:

### Resource Categories

1. **Colors** (9 categories)
   - Background, Foreground, Border, Panel, Input, State Marks, ScrollBar

2. **Brushes** (9 categories)
   - Solid color brushes wrapping the color resources

3. **CornerRadius** (6 components)
   - Button, ToggleButton, TextBox, CheckBox, RadioButton, ComboBox

### How to Override Resources

Resources can be overridden in three ways:

1. **At the application level** (affects entire app)
2. **At the window level** (affects specific window)
3. **At the control level** (affects specific control or panel)

## How to Customize the Theme

### Option 1: Override Colors Directly

To change the appearance of all components with specific state, override the corresponding color resource in your application:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <!-- Include the toolkit theme -->
            <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
        
        <!-- Override colors to customize appearance -->
        <Color x:Key="Colors.Background.Static">#FF1E3A8A</Color>
        <Color x:Key="Colors.Foreground.Static">#FFFFFFFF</Color>
        <Color x:Key="Colors.Border.Static">#FF0F172A</Color>
        
        <!-- You can also override CornerRadius values -->
        <CornerRadius x:Key="Button.CornerRadius.Static">8</CornerRadius>
        <CornerRadius x:Key="TextBox.CornerRadius.Static">5</CornerRadius>
        <!-- ... override other colors and resources as needed ... -->
    </ResourceDictionary>
</Application.Resources>
```

### Option 2: Override Brushes

If you only want to customize certain brushes, you can override the brush resources instead of colors:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
        
        <!-- Override specific brushes -->
        <SolidColorBrush x:Key="Brushes.Background.Static" Color="#FF1E3A8A"/>
        <SolidColorBrush x:Key="Brushes.Foreground.Static" Color="#FFFFFFFF"/>
    </ResourceDictionary>
</Application.Resources>
```

### Option 3: Override CornerRadius Resources

To change the corner radius of buttons, text boxes, or other controls:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
        
        <!-- Make all buttons square (no corners) -->
        <CornerRadius x:Key="Button.CornerRadius.Static">0</CornerRadius>
        <CornerRadius x:Key="Button.CornerRadius.MouseOver">0</CornerRadius>
        <CornerRadius x:Key="Button.CornerRadius.Pressed">0</CornerRadius>
        <CornerRadius x:Key="Button.CornerRadius.Disabled">0</CornerRadius>
        
        <!-- Make text boxes highly rounded -->
        <CornerRadius x:Key="TextBox.CornerRadius.Static">10</CornerRadius>
        <CornerRadius x:Key="TextBox.CornerRadius.MouseOver">10</CornerRadius>
        <CornerRadius x:Key="TextBox.CornerRadius.Focused">10</CornerRadius>
        <CornerRadius x:Key="TextBox.CornerRadius.Disabled">10</CornerRadius>
    </ResourceDictionary>
</Application.Resources>
```

### Option 4: Override Multiple Resource Types

Combine colors, brushes, and corner radius overrides for complete customization:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
        
        <!-- Colors -->
        <Color x:Key="Colors.Background.Static">#FF3B82F6</Color>
        <Color x:Key="Colors.Foreground.Static">#FFFFFFFF</Color>
        
        <!-- Brushes -->
        <SolidColorBrush x:Key="Brushes.Background.Static" Color="{DynamicResource Colors.Background.Static}"/>
        <SolidColorBrush x:Key="Brushes.Foreground.Static" Color="{DynamicResource Colors.Foreground.Static}"/>
        
        <!-- CornerRadius -->
        <CornerRadius x:Key="Button.CornerRadius.Static">6</CornerRadius>
    </ResourceDictionary>
</Application.Resources>
```

### Option 5: Create a Complete Custom Theme

Create a new ResourceDictionary file with your own color, brush, and corner radius definitions:

```xaml
<!-- MyCustomTheme.xaml -->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <!-- Define your custom colors -->
    <Color x:Key="Colors.Background.Static">#FF1E40AF</Color>
    <!-- ... define all other colors ... -->
    
    <!-- Define your custom brushes -->
    <SolidColorBrush x:Key="Brushes.Background.Static" Color="{DynamicResource Colors.Background.Static}"/>
    <!-- ... define all other brushes ... -->
    
    <!-- Define your custom corner radii -->
    <CornerRadius x:Key="Button.CornerRadius.Static">4</CornerRadius>
    <CornerRadius x:Key="TextBox.CornerRadius.Static">3</CornerRadius>
    <!-- ... define all other corner radii ... -->
</ResourceDictionary>
```

Then in your application:

```xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <!-- Include your custom theme instead of the default -->
            <ResourceDictionary Source="MyCustomTheme.xaml"/>
            <!-- Include the toolkit styles (which will use your colors) -->
            <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Component Usage Examples

### Changing Button Appearance

Buttons use these color and shape resources:
- `Colors.Background.*` for button background
- `Colors.Foreground.*` for button text
- `Colors.Border.*` for button border
- `Button.CornerRadius.*` for border roundness

To create a red-themed button appearance:

```xaml
<Color x:Key="Colors.Background.Static">#FFDC2626</Color>
<Color x:Key="Colors.Background.MouseOver">#FFEF4444</Color>
<Color x:Key="Colors.Background.Pressed">#FFB91C1C</Color>
<Color x:Key="Colors.Border.Static">#FF7F1D1D</Color>

<!-- Make buttons fully rounded -->
<CornerRadius x:Key="Button.CornerRadius.Static">20</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.MouseOver">20</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Pressed">20</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Disabled">20</CornerRadius>
```

### Changing Input Field Appearance

TextBox and similar input controls use:
- `Colors.InputBackground.*` for field background
- `Colors.InputForeground.*` for text color
- `TextBox.CornerRadius.*` for border roundness

To create a high-contrast input theme with rounded corners:

```xaml
<Color x:Key="Colors.InputBackground.Static">#FF000000</Color>
<Color x:Key="Colors.InputForeground.Static">#FFFFFF00</Color>
<Color x:Key="Colors.InputBackground.MouseOver">#FF0F0F0F</Color>
<Color x:Key="Colors.InputForeground.MouseOver">#FFFFFF00</Color>

<!-- Make text boxes rounded -->
<CornerRadius x:Key="TextBox.CornerRadius.Static">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.MouseOver">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Focused">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Disabled">8</CornerRadius>
```

### Changing CheckBox/RadioButton Indicator Color and Shape

CheckBox checkmarks and RadioButton indicators use:
- `Colors.StateMark.*` for the indicator color
- `CheckBox.CornerRadius.*` for CheckBox corner radius
- `RadioButton.CornerRadius.*` for RadioButton corner radius (typically remains circular at 8)

To use a green indicator with modified checkbox corners:

```xaml
<Color x:Key="Colors.StateMark.Checked">#FF10B981</Color>
<Color x:Key="Colors.StateMark.CheckedMouseOver">#FF34D399</Color>
<Color x:Key="Colors.StateMark.CheckedPressed">#FF059669</Color>

<!-- Make checkboxes more square -->
<CornerRadius x:Key="CheckBox.CornerRadius.Static">1</CornerRadius>
<CornerRadius x:Key="CheckBox.CornerRadius.Checked">1</CornerRadius>
```

### Customizing Multiple Controls at Once

To create a cohesive design with consistent styling across all controls:

```xaml
<!-- Define a consistent color scheme -->
<Color x:Key="Colors.Background.Static">#FF1F2937</Color>
<Color x:Key="Colors.Background.MouseOver">#FF374151</Color>
<Color x:Key="Colors.Background.Pressed">#FF111827</Color>
<Color x:Key="Colors.Border.Static">#FF4B5563</Color>
<Color x:Key="Colors.Foreground.Static">#FFF3F4F6</Color>

<!-- Apply consistent corner radius -->
<CornerRadius x:Key="Button.CornerRadius.Static">6</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.MouseOver">6</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Pressed">6</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Disabled">6</CornerRadius>

<CornerRadius x:Key="TextBox.CornerRadius.Static">6</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.MouseOver">6</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Focused">6</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Disabled">6</CornerRadius>

<CornerRadius x:Key="ComboBox.CornerRadius.Static">6</CornerRadius>
```

## Dynamic Runtime Theming

Since brushes use `{DynamicResource}` bindings and resources are resolved at runtime, you can change colors and other properties dynamically by updating the resource dictionaries:

```csharp
// Change a color at runtime
Application.Current.Resources["Colors.Background.Static"] = Color.FromRgb(0x1E, 0x3A, 0x8A);

// Change a corner radius at runtime
Application.Current.Resources["Button.CornerRadius.Static"] = new CornerRadius(10);

// The changes will automatically propagate to all controls using these resources
```

## Best Practices

1. **Maintain Consistency**: When creating custom themes, ensure that related states (e.g., Static, MouseOver, Pressed) have appropriate contrast and visual hierarchy. Apply the same corner radius values across related states of a component.

2. **Use Dynamic Resources**: Always use `{DynamicResource}` bindings in custom styles to allow runtime theme changes. Both color brushes and corner radius values support dynamic updates.

3. **Test All States**: When overriding resources, test all control states:
   - Normal (Static)
   - Mouse Over
   - Pressed/Active/Focused (depending on control type)
   - Checked (where applicable)
   - Disabled

4. **Corner Radius Consistency**: Keep corner radius values consistent within a theme:
   - Buttons: typically 5-8
   - TextBoxes: typically 3-6
   - CheckBox: typically 2-4
   - RadioButton: typically 8 (circular)
   - ComboBox: typically 3-6

5. **Contrast and Accessibility**: 
   - Ensure sufficient contrast between foreground and background colors for readability (WCAG AA standard recommends 4.5:1 for text)
   - Test your theme with both light and dark backgrounds
   - Verify that disabled states are clearly distinguishable

6. **Color Naming Convention**: If overriding multiple colors, use a consistent naming pattern to track which colors are customized

7. **Keep Default Theme**: Consider keeping the default theme available as a fallback or for comparison

8. **Override Hierarchy**: Remember the override priority:
   - Direct control property setters (highest priority)
   - Control-level resources
   - Window-level resources
   - Application-level resources
   - Default toolkit resources (lowest priority)

## Control-to-Resource Reference

Quick lookup for which resources affect specific controls:

| Control | Color Resources | Brush Resources | CornerRadius Resources | Other Resources |
|---------|-----------------|-----------------|------------------------|-----------------|
| **Button** | Background, Foreground, Border | Brushes.Background, Brushes.Foreground, Brushes.Border | Button.CornerRadius.* | — |
| **ToggleButton** | Background, Foreground, Border, Checked | Brushes.Background, Brushes.Foreground, Brushes.Border | ToggleButton.CornerRadius.* | — |
| **TextBox** | InputBackground, InputForeground, Border | Brushes.InputBackground, Brushes.InputForeground, Brushes.Border | TextBox.CornerRadius.* | — |
| **CheckBox** | Background, Foreground, Border, StateMark | Brushes.Background, Brushes.Foreground, Brushes.Border, Brushes.StateMark | CheckBox.CornerRadius.* | — |
| **RadioButton** | Background, Foreground, Border, StateMark | Brushes.Background, Brushes.Foreground, Brushes.Border, Brushes.StateMark | RadioButton.CornerRadius.* | — |
| **ComboBox** | InputBackground, InputForeground, Border, PanelBackground, PanelForeground, Foreground | ComboBox.Brushes.Glyph.*, ComboBox.Brushes.InputBackground.*, ComboBox.Brushes.Border.*, ComboBox.Brushes.Popup.* | ComboBox.CornerRadius.* | — |
| **TabControl** | PanelBackground, PanelForeground, Border | Brushes.PanelBackground.*, Brushes.PanelForeground.*, Brushes.Border.*, TabItem.Selected.* | — | — |
| **GroupBox** | PanelBackground, Border | Brushes.PanelBackground.*, GroupBox.InnerBorderBrush | GroupBox.CornerRadius | GroupBox.InnerBorderThickness |
| **ScrollBar** | ScrollBar.Track, ScrollBar.Thumb.* | Brushes.ScrollBar.* | — | — |

## Common Customization Scenarios

### Create a Dark Theme

Dark themes are already the default, but here's how to customize them further with a more muted palette:

```xaml
<!-- Define a darker, more muted color scheme -->
<Color x:Key="Colors.Background.Static">#FF2C3E50</Color>
<Color x:Key="Colors.Background.MouseOver">#FF34495E</Color>
<Color x:Key="Colors.Background.Pressed">#FF1A252F</Color>
<Color x:Key="Colors.Foreground.Static">#FFE8EAED</Color>
<Color x:Key="Colors.Border.Static">#FF546E7A</Color>
<Color x:Key="Colors.PanelBackground.Primary">#FF212C36</Color>
<Color x:Key="Colors.InputBackground.Static">#FF263238</Color>
```

### Create a Light Theme

```xaml
<!-- Light color scheme -->
<Color x:Key="Colors.Background.Static">#FFFAFAFA</Color>
<Color x:Key="Colors.Background.MouseOver">#FFF5F5F5</Color>
<Color x:Key="Colors.Background.Pressed">#FFEEEEEE</Color>
<Color x:Key="Colors.Foreground.Static">#FF212121</Color>
<Color x:Key="Colors.Border.Static">#FFBDBDBD</Color>
<Color x:Key="Colors.PanelBackground.Primary">#FFFFFF</Color>
<Color x:Key="Colors.PanelBackground.Secondary">#FFF5F5F5</Color>
<Color x:Key="Colors.InputBackground.Static">#FFFFFFFF</Color>
<Color x:Key="Colors.InputForeground.Static">#FF424242</Color>
```

### Create a High-Contrast Theme

```xaml
<!-- High contrast for accessibility -->
<Color x:Key="Colors.Background.Static">#FF000000</Color>
<Color x:Key="Colors.Background.MouseOver">#FF1A1A1A</Color>
<Color x:Key="Colors.Background.Pressed">#FF333333</Color>
<Color x:Key="Colors.Foreground.Static">#FFFFFFFF</Color>
<Color x:Key="Colors.Border.Static">#FFFFFFFF</Color>
<Color x:Key="Colors.InputBackground.Static">#FF000000</Color>
<Color x:Key="Colors.InputForeground.Static">#FFFFFFFF</Color>
<Color x:Key="Colors.PanelBackground.Primary">#FF000000</Color>
```

### Customize Borders and Spacing

```xaml
<!-- Adjust border thicknesses for different visual weight -->
<Thickness x:Key="GroupBox.InnerBorderThickness">2</Thickness>

<!-- Adjust corner radius for a more rounded appearance -->
<CornerRadius x:Key="Button.CornerRadius.Static">8</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.MouseOver">8</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Pressed">8</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Disabled">8</CornerRadius>

<CornerRadius x:Key="TextBox.CornerRadius.Static">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.MouseOver">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Focused">8</CornerRadius>
<CornerRadius x:Key="TextBox.CornerRadius.Disabled">8</CornerRadius>

<CornerRadius x:Key="GroupBox.CornerRadius">8</CornerRadius>
```

## Troubleshooting

### Resources Not Updating at Runtime

**Issue**: Changed `Application.Current.Resources["Color.Background.Static"]` but controls didn't update.

**Solution**: Ensure you're using `{DynamicResource}` bindings in your styles, not `{StaticResource}`. All toolkit styles use `{DynamicResource}`, but custom styles must as well.

```xaml
<!-- Correct: uses dynamic binding -->
<SolidColorBrush x:Key="MyBrush" Color="{DynamicResource Colors.Background.Static}"/>

<!-- Incorrect: uses static binding and won't update -->
<SolidColorBrush x:Key="MyBrush" Color="{StaticResource Colors.Background.Static}"/>
```

### Brushes Override Not Working

**Issue**: Overriding a brush resource doesn't affect the controls.

**Solution**: Ensure brushes inherit the colors after your color overrides. Order matters:

```xaml
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <!-- First, include the toolkit theme -->
        <ResourceDictionary Source="pack://application:,,,/OffAxis.Wpf.Toolkit;component/UIThemes/Styles.xaml"/>
    </ResourceDictionary.MergedDictionaries>
    
    <!-- Then override colors (lowest level) -->
    <Color x:Key="Colors.Background.Static">#FF1E3A8A</Color>
    
    <!-- If needed, override specific brushes (middle level) -->
    <SolidColorBrush x:Key="Brushes.Background.Static" Color="{DynamicResource Colors.Background.Static}"/>
    
    <!-- Most specific: override directly in control (highest level) -->
    <!-- This should be done in control's properties, not in resources -->
</ResourceDictionary>
```

### Theme Changes Only Partially Applied

**Issue**: Some controls updated but others didn't when changing a theme.

**Solution**: Verify that all affected controls are using the correct color resources. Check that custom styles reference the same resource keys as the toolkit styles. Use the Control-to-Resource Reference table above to identify which resources affect each control.

### CornerRadius Changes Not Visible

**Issue**: Changed corner radius values but borders still appear sharp/rounded.

**Solution**: 
1. Verify the control template actually uses the CornerRadius resource
2. Ensure you're overriding all relevant states (Static, MouseOver, Pressed, etc.)
3. Some controls (like RadioButton) maintain a circular shape; values are typically set to 8

```xaml
<!-- Example: Override all Button corner radius states -->
<CornerRadius x:Key="Button.CornerRadius.Static">10</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.MouseOver">10</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Pressed">10</CornerRadius>
<CornerRadius x:Key="Button.CornerRadius.Disabled">10</CornerRadius>
```

### Disabled State Not Visually Distinct

**Issue**: Disabled controls don't look obviously disabled.

**Solution**: Ensure the disabled color resources provide sufficient contrast. Consider using a more muted or washed-out color for disabled states:

```xaml
<Color x:Key="Colors.Background.Disabled">#FF757575</Color>
<Color x:Key="Colors.Foreground.Disabled">#FFBDBDBD</Color>
<Color x:Key="Colors.Border.Disabled">#FF9E9E9E</Color>
```

## File Locations

- **Colors definition**: `OffAxis.Wpf.Toolkit/UIThemes/Colors.xaml`
- **Brushes definition**: `OffAxis.Wpf.Toolkit/UIThemes/Brushes.xaml`
- **Main styles**: `OffAxis.Wpf.Toolkit/UIThemes/Styles.xaml`
- **Component styles**: `OffAxis.Wpf.Toolkit/UIThemes/Styles/` directory
- **GroupBox styles**: `OffAxis.Wpf.Toolkit/UIThemes/Styles/GroupBox/GroupBox.Style.xaml`
