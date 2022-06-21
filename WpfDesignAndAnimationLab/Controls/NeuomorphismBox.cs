using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(NeuomorphismBox), new PropertyMetadata(new CornerRadius(50)));

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
        /// 标识 LightSource 依赖属性。
        /// </summary>
        public static readonly DependencyProperty LightSourceProperty =
            DependencyProperty.Register(nameof(LightSource), typeof(NeuomorphismLightSource), typeof(NeuomorphismBox), new PropertyMetadata(default(NeuomorphismLightSource), OnLightSourceChanged));

        /// <summary>
        /// 标识 Shape 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register(nameof(Shape), typeof(NeuomorphismShape), typeof(NeuomorphismBox), new PropertyMetadata(NeuomorphismShape.Flat, OnShapeChanged));

        /// <summary>
        /// 标识 TemplateSettings 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TemplateSettingsProperty =
            DependencyProperty.Register(nameof(TemplateSettings), typeof(NeuomorphismBoxTemplateSettings), typeof(NeuomorphismBox), new PropertyMetadata(null));

        private bool _hasApplyTemplate;

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
        /// 获取或设置LightSource的值
        /// </summary>
        public NeuomorphismLightSource LightSource
        {
            get => (NeuomorphismLightSource)GetValue(LightSourceProperty);
            set => SetValue(LightSourceProperty, value);
        }

        /// <summary>
        /// 获取或设置Shape的值
        /// </summary>
        public NeuomorphismShape Shape
        {
            get => (NeuomorphismShape)GetValue(ShapeProperty);
            set => SetValue(ShapeProperty, value);
        }

        /// <summary>
        /// 获取或设置TemplateSettings的值
        /// </summary>
        public NeuomorphismBoxTemplateSettings TemplateSettings
        {
            get => (NeuomorphismBoxTemplateSettings)GetValue(TemplateSettingsProperty);
            set => SetValue(TemplateSettingsProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _hasApplyTemplate = true;
            UpdateTemplateSettings();
        }

        /// <summary>
        /// Blur 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Blur 属性的旧值。</param>
        /// <param name="newValue">Blur 属性的新值。</param>
        protected virtual void OnBlurChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        /// Color 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Color 属性的旧值。</param>
        /// <param name="newValue">Color 属性的新值。</param>
        protected virtual void OnColorChanged(Color oldValue, Color newValue) => UpdateTemplateSettings();

        /// <summary>
        /// Distance 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Distance 属性的旧值。</param>
        /// <param name="newValue">Distance 属性的新值。</param>
        protected virtual void OnDistanceChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        /// Intensity 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Intensity 属性的旧值。</param>
        /// <param name="newValue">Intensity 属性的新值。</param>
        protected virtual void OnIntensityChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        /// LightSource 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">LightSource 属性的旧值。</param>
        /// <param name="newValue">LightSource 属性的新值。</param>
        protected virtual void OnLightSourceChanged(NeuomorphismLightSource oldValue, NeuomorphismLightSource newValue) => UpdateTemplateSettings();

        /// <summary>
        /// Shape 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Shape 属性的旧值。</param>
        /// <param name="newValue">Shape 属性的新值。</param>
        protected virtual void OnShapeChanged(NeuomorphismShape oldValue, NeuomorphismShape newValue) => UpdateTemplateSettings();

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

        private static void OnLightSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnLightSourceChanged((NeuomorphismLightSource)args.OldValue, (NeuomorphismLightSource)args.NewValue);
        }

        private static void OnShapeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as NeuomorphismBox;
            target?.OnShapeChanged((NeuomorphismShape)args.OldValue, (NeuomorphismShape)args.NewValue);
        }
        private void UpdateTemplateSettings()
        {
            if (_hasApplyTemplate == false)
                return;

            TemplateSettings = new NeuomorphismBoxTemplateSettings(Color, Distance, Intensity, Blur, Shape, LightSource);
        }
    }
}
