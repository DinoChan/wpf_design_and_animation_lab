using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace WpfDesignAndAnimationLab.Controls
{
    public class InnerShadowBox : ContentControl
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(InnerShadowBox), new PropertyMetadata(default(CornerRadius)));

        public static readonly DependencyProperty InnerShadowEffectProperty =
            DependencyProperty.Register(nameof(InnerShadowEffect), typeof(DropShadowEffect), typeof(InnerShadowBox), new PropertyMetadata(null));

        public InnerShadowBox() => DefaultStyleKey = typeof(InnerShadowBox);

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public DropShadowEffect InnerShadowEffect
        {
            get => (DropShadowEffect)GetValue(InnerShadowEffectProperty);
            set => SetValue(InnerShadowEffectProperty, value);
        }
    }
}