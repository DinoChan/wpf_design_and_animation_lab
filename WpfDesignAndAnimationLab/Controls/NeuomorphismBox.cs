using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    public class NeuomorphismBox : ContentControl
    {
        /// <summary>
        /// 标识 Blur 依赖属性。
        /// </summary>
        public static readonly DependencyProperty BlurProperty =
            DependencyProperty.Register(nameof(Blur), typeof(double), typeof(NeuomorphismBox), new PropertyMetadata(60d, OnBlurChanged));

        /// <summary>
        /// 标识 Color 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Color), typeof(NeuomorphismBox), new PropertyMetadata(default(Color), OnColorChanged));

        /// <summary>
        /// 标识 CornerRadius 依赖属性。
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(NeuomorphismBox), new PropertyMetadata(new CornerRadius(50), OnCornerRadiusChanged));

        /// <summary>
        /// 标识 DarkShadowColor 依赖属性。
        /// </summary>
        public static readonly DependencyPropertyKey DarkShadowColorPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(DarkShadowColor), typeof(Color), typeof(NeuomorphismBox), new PropertyMetadata(Color.FromRgb(224, 224, 224), OnDarkShadowColorChanged));

        public static readonly DependencyProperty DarkShadowColorProperty = DarkShadowColorPropertyKey.DependencyProperty;

        /// <summary>
        /// 标识 Distance 依赖属性。
        /// </summary>
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register(nameof(Distance), typeof(double), typeof(NeuomorphismBox), new PropertyMetadata(20d, OnDistanceChanged));

        /// <summary>
        /// 标识 Intensity 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty.Register(nameof(Intensity), typeof(double), typeof(NeuomorphismBox), new PropertyMetadata(0.15d, OnIntensityChanged));

        /// <summary>
        /// 标识 LightShaowColor 依赖属性。
        /// </summary>
        public static readonly DependencyPropertyKey LightShadowColorPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(nameof(LightShadowColor), typeof(Color), typeof(NeuomorphismBox), new PropertyMetadata(default(Color), OnLightShaowColorChanged));

        public static readonly DependencyProperty LightShadowColorProperty = LightShadowColorPropertyKey.DependencyProperty;

        public NeuomorphismBox()
        {
            DefaultStyleKey = typeof(NeuomorphismBox);
        }

        /// <summary>
        /// 获取或设置Blur的值
        /// </summary>
        public double Blur
        {
            get => (double)GetValue(BlurProperty);
            set => SetValue(BlurProperty, value);
        }

        /// <summary>
        /// 获取或设置Color的值
        /// </summary>
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        /// <summary>
        /// 获取或设置CornerRadius的值
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// 获取或设置DarkShadowColor的值
        /// </summary>
        public Color DarkShadowColor
        {
            get => (Color)GetValue(DarkShadowColorProperty);
        }

        /// <summary>
        /// 获取或设置Distance的值
        /// </summary>
        public double Distance
        {
            get => (double)GetValue(DistanceProperty);
            set => SetValue(DistanceProperty, value);
        }

        /// <summary>
        /// 获取或设置Intensity的值
        /// </summary>
        public double Intensity
        {
            get => (double)GetValue(IntensityProperty);
            set => SetValue(IntensityProperty, value);
        }

        /// <summary>
        /// 获取或设置LightShaowColor的值
        /// </summary>
        public Color LightShadowColor
        {
            get => (Color)GetValue(LightShadowColorProperty);
        }

        /// <summary>
        /// Blur 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Blur 属性的旧值。</param>
        /// <param name="newValue">Blur 属性的新值。</param>
        protected virtual void OnBlurChanged(double oldValue, double newValue)
        {
        }

        /// <summary>
        /// Color 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Color 属性的旧值。</param>
        /// <param name="newValue">Color 属性的新值。</param>
        protected virtual void OnColorChanged(Color oldValue, Color newValue)
        {
            SetValue(DarkShadowColorPropertyKey, ColorHelper.ColorWithLuminance(newValue, Intensity * -1));
            SetValue(LightShadowColorPropertyKey, ColorHelper.ColorWithLuminance(newValue, Intensity));
        }

        /// <summary>
        /// CornerRadius 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">CornerRadius 属性的旧值。</param>
        /// <param name="newValue">CornerRadius 属性的新值。</param>
        protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
        {
        }

        /// <summary>
        /// DarkShadowColor 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">DarkShadowColor 属性的旧值。</param>
        /// <param name="newValue">DarkShadowColor 属性的新值。</param>
        protected virtual void OnDarkShadowColorChanged(Color oldValue, Color newValue)
        {
        }

        /// <summary>
        /// Distance 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Distance 属性的旧值。</param>
        /// <param name="newValue">Distance 属性的新值。</param>
        protected virtual void OnDistanceChanged(double oldValue, double newValue)
        {
        }

        /// <summary>
        /// Intensity 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Intensity 属性的旧值。</param>
        /// <param name="newValue">Intensity 属性的新值。</param>
        protected virtual void OnIntensityChanged(double oldValue, double newValue)
        {
        }

        /// <summary>
        /// LightShaowColor 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">LightShaowColor 属性的旧值。</param>
        /// <param name="newValue">LightShaowColor 属性的新值。</param>
        protected virtual void OnLightShaowColorChanged(Color oldValue, Color newValue)
        {
        }

        private static void OnBlurChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnBlurChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnColorChanged((Color)args.OldValue, (Color)args.NewValue);
        }

        private static void OnCornerRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnCornerRadiusChanged((CornerRadius)args.OldValue, (CornerRadius)args.NewValue);
        }

        private static void OnDarkShadowColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnDarkShadowColorChanged((Color)args.OldValue, (Color)args.NewValue);
        }

        private static void OnDistanceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnDistanceChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnIntensityChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnIntensityChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnLightShaowColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (Color)args.OldValue;
            var newValue = (Color)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as NeuomorphismBox;
            target?.OnLightShaowColorChanged(oldValue, newValue);
        }


    }
}
