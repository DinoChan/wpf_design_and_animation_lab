using System.Windows.Shapes;
using System.Windows.Controls;
using System.Diagnostics;
using System.Threading;

using System.Windows;
using System.Windows.Media;
using System.Linq;
using System;

namespace WpfDesignAndAnimationLab.Controls
{
    public class ShadowChrome : Decorator
    {
        public ShadowChrome()
        {

        }
        private const double ShadowDepth = 30;


        /// <summary>
        /// 获取或设置CornerRadius的值
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="CornerRadius" /> property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
                DependencyProperty.Register(
                        "CornerRadius",
                        typeof(CornerRadius),
                        typeof(ShadowChrome),
                        new FrameworkPropertyMetadata(
                                new CornerRadius(),
                                FrameworkPropertyMetadataOptions.AffectsRender,
                               null),
                        new ValidateValueCallback(IsCornerRadiusValid));

        private static bool IsCornerRadiusValid(object value)
        {
            CornerRadius cr = (CornerRadius)value;
            return !(cr.TopLeft < 0.0 || cr.TopRight < 0.0 || cr.BottomLeft < 0.0 || cr.BottomRight < 0.0 ||
                     double.IsNaN(cr.TopLeft) || double.IsNaN(cr.TopRight) || double.IsNaN(cr.BottomLeft) || double.IsNaN(cr.BottomRight) ||
                     double.IsInfinity(cr.TopLeft) || double.IsInfinity(cr.TopRight) || double.IsInfinity(cr.BottomLeft) || double.IsInfinity(cr.BottomRight));
        }


        /// <summary>
        /// 获取或设置BlurRadius的值
        /// </summary>
        public double BlurRadius
        {
            get => (double)GetValue(BlurRadiusProperty);
            set => SetValue(BlurRadiusProperty, value);
        }

        /// <summary>
        /// 标识 BlurRadius 依赖属性。
        /// </summary>
        public static readonly DependencyProperty BlurRadiusProperty =
            DependencyProperty.Register(nameof(BlurRadius), typeof(double), typeof(ShadowChrome), new FrameworkPropertyMetadata(5d, FrameworkPropertyMetadataOptions.AffectsRender));



        /// <summary>
        /// 获取或设置Direction的值
        /// </summary>
        public double Direction
        {
            get => (double)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        /// <summary>
        /// 标识 Direction 依赖属性。
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register(nameof(Direction), typeof(double), typeof(ShadowChrome), new FrameworkPropertyMetadata(315d, FrameworkPropertyMetadataOptions.AffectsRender));



        /// <summary>
        /// 获取或设置Color的值
        /// </summary>
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        /// <summary>
        /// 标识 Color 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Color), typeof(ShadowChrome), new FrameworkPropertyMetadata(
                                Color.FromArgb(255, 0x00, 0x00, 0x00),
                                FrameworkPropertyMetadataOptions.AffectsRender,
                                null));

        protected override void OnRender(DrawingContext drawingContext)
        {
            var blurRadius = (int)Math.Round(BlurRadius, 0);

            Rect shadowBounds = new Rect(new Point(blurRadius, blurRadius),
                             new Size(RenderSize.Width, RenderSize.Height));
            Color color = Color;
            var weights = GetWeights(blurRadius);

            if (shadowBounds.Width > 0 && shadowBounds.Height > 0 && color.A > 0)
            {

                for (int i = 0; i < blurRadius; i++)
                {
                    var cornerRadius = CornerRadius;
                    var geometry = CreateGeometry(RenderSize.Width, RenderSize.Height, cornerRadius, -i - 1);
                    Brush brush = new SolidColorBrush(Color.FromArgb((byte)(Math.Min(1, weights[i]) * 255), Color.R, Color.G, Color.B));
                    drawingContext.DrawGeometry(brush, new Pen(brush, 1), geometry);
                }
            }
        }

        private static ArcSegment CreateArcSegment(Point point, double radius)
        {
            return new ArcSegment
            {
                Point = point,
                Size = new Size(radius, radius),
                IsLargeArc = false,
                SweepDirection = SweepDirection.Clockwise
            };
        }


        private static PathGeometry CreateGeometry(double width, double height, CornerRadius cornerRadius, double margin)
        {
            var top = margin;
            var bottom = height - margin;
            var left = margin;
            var right = width - margin;
            var actualCornerRadius = new CornerRadius(Math.Max(0, cornerRadius.TopLeft - margin), Math.Max(0, cornerRadius.TopRight - margin), Math.Max(0, cornerRadius.BottomRight - margin), Math.Max(0, cornerRadius.TopLeft - margin));

            var figure = new PathFigure { IsClosed = true, IsFilled = false, StartPoint = new Point(left, cornerRadius.TopLeft) };
            figure.Segments.Add(CreateArcSegment(new Point(cornerRadius.TopLeft, top), actualCornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(width - cornerRadius.TopRight, margin) });
            figure.Segments.Add(CreateArcSegment(new Point(right, cornerRadius.TopRight), actualCornerRadius.TopRight));
            figure.Segments.Add(new LineSegment { Point = new Point(right, height - cornerRadius.TopRight) });
            figure.Segments.Add(CreateArcSegment(new Point(width - cornerRadius.BottomRight, bottom), actualCornerRadius.BottomRight));
            figure.Segments.Add(new LineSegment { Point = new Point(cornerRadius.BottomLeft, bottom) });
            figure.Segments.Add(CreateArcSegment(new Point(left, height - cornerRadius.BottomLeft), actualCornerRadius.BottomLeft));
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);

            return pathGeometry;
        }



        private double[] GetWeights(int radius = 5)
        {
            double sum = 0.0;
            var pSamplingWeights = new double[radius + 1];

            for (var i = 0; i < pSamplingWeights.Length; i++)
            {
                // Choosing a standard deviation of 1/3rd the radius is standard for a discrete
                // approximation of the gaussian function.
                double sd = radius / 3.0;
                double ind = (double)i;
                double weight = (1.0 / (sd * Math.Sqrt(Math.PI * 2))) * Math.Exp(-(ind * ind) / (2.0 * sd * sd));
                // Sum the weights as we go so we can normalize them at the end to ensure conservation of intensity.
                if (i == 0)
                {
                    sum += weight;
                }
                else
                {
                    sum += weight;
                    sum += weight;
                }
                pSamplingWeights[i] = weight;
            }

            var sumWeight = 0.0;
            var result = new double[radius];
            for (int i = radius - 1; i >= 0; i--)
            {
                sumWeight += pSamplingWeights[i];
                result[i] = sumWeight;
            }

            //for (int i = 0; i < radius; i++)
            //{
            //    result[i] = pSamplingWeights.Skip(i).Sum();
            //}

            return result;
        }
    }
}
