using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace WpfDesignAndAnimationLab.Controls
{
    public class InnerShadowBox : ContentControl
    {
        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(InnerShadowBox),
                new PropertyMetadata(new CornerRadius(0)));

        // Using a DependencyProperty as the backing store for dropShadowEffect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerShadowEffectProperty =
            DependencyProperty.Register("InnerShadowEffect", typeof(DropShadowEffect), typeof(InnerShadowBox),
                new PropertyMetadata(null));

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