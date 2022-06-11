using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace WpfDesignAndAnimationLab.Controls
{
    public class InnerShadowBox : ContentControl
    {
        public InnerShadowBox()
        {
            DefaultStyleKey = typeof(InnerShadowBox);
            
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(InnerShadowBox), new PropertyMetadata(new CornerRadius(0)));



        public DropShadowEffect InnerShadowEffect
        {
            get { return (DropShadowEffect)GetValue(InnerShadowEffectProperty); }
            set { SetValue(InnerShadowEffectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dropShadowEffect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerShadowEffectProperty =
            DependencyProperty.Register("InnerShadowEffect", typeof(DropShadowEffect), typeof(InnerShadowBox), new PropertyMetadata(null));


    }
}
