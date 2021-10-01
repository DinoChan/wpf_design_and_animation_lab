using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WpfDesignAndAnimationLab.AnimationDemos.OutlinedText
{
    public class OutlinedTextControl : Control
    {

        /// <summary>
        /// 标识 Bold 依赖属性。
        /// </summary>
        public static readonly DependencyProperty BoldProperty =
            DependencyProperty.Register(nameof(Bold), typeof(bool), typeof(OutlinedTextControl), new FrameworkPropertyMetadata(
                    default(bool),
                    FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// 标识 Italic 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ItalicProperty =
            DependencyProperty.Register(nameof(Italic), typeof(bool), typeof(OutlinedTextControl), new FrameworkPropertyMetadata(
                    default(bool),
                    FrameworkPropertyMetadataOptions.AffectsRender));

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
                    default(string),
                    FrameworkPropertyMetadataOptions.AffectsRender));
        private Geometry _geometry;

        /// <summary>
        /// 获取或设置Bold的值
        /// </summary>
        public bool Bold
        {
            get => (bool)GetValue(BoldProperty);
            set => SetValue(BoldProperty, value);
        }

        /// <summary>
        /// 获取或设置Italic的值
        /// </summary>
        public bool Italic
        {
            get => (bool)GetValue(ItalicProperty);
            set => SetValue(ItalicProperty, value);
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


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var geometry = CreateText();

            // Draw the outline based on the properties that are set.
            drawingContext.DrawGeometry(Foreground, new Pen(Stroke, StrokeThickness), geometry);

            if (_geometry == null || _geometry.Bounds.Size != geometry.Bounds.Size)
            {
                _geometry = geometry;
                InvalidateMeasure();
            }
        }

        private double _height;
        private double _width;

        private Geometry CreateText()
        {
            System.Windows.FontStyle fontStyle = FontStyles.Normal;
            FontWeight fontWeight = FontWeights.Medium;

            // Create the formatted text based on the properties set.
            FormattedText formattedText = new FormattedText(
                Text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(
                    FontFamily,
                    FontStyle,
                    FontWeight,
                    FontStretches.Normal),
                FontSize,
                System.Windows.Media.Brushes.Black,// This brush does not matter since we use the geometry of the text.
                100);
            // Build the geometry object that represents the text.


            //formattedText.MaxTextWidth = 500;
            _height = formattedText.Height;
            _width = formattedText.Width;
            return formattedText.BuildGeometry(new Point(0, 0));
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (_geometry == null)
                return Size.Empty;

            return new Size(_width, _height);
        }
    }
}
