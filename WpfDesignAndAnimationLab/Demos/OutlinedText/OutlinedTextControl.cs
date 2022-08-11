using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Demos.OutlinedText
{
    public class OutlinedTextControl : Control
    {
        /// <summary>
        /// 标识 Stroke 依赖属性。
        /// </summary>
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register(nameof(Stroke), typeof(Brush), typeof(OutlinedTextControl), new FrameworkPropertyMetadata(
                   Brushes.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// 标识 StrokeThickness 依赖属性。
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(OutlinedTextControl), new FrameworkPropertyMetadata(
                    default(double),
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// 标识 Text 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(OutlinedTextControl), new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.AffectsRender));

        public OutlinedTextControl()
        {
            DefaultStyleKey = typeof(OutlinedTextControl);
        }

        /// <summary>
        /// 获取或设置Stroke的值
        /// </summary>
        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        /// <summary>
        /// <summary>
        /// StrokeThickness
        /// </summary>
        public double StrokeThickness
        {
            get => (double)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        /// <summary>
        /// 获取或设置Text的值
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}