using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Common
{
    public class GeometryCreator : FrameworkElement
    {
        /// <summary>
        ///     标识 CornerRadius 依赖属性。
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GeometryCreator),
                new PropertyMetadata(default(CornerRadius), OnCornerRadiusChanged));

        /// <summary>
        ///     标识 GeometryHeight 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GeometryHeightProperty =
            DependencyProperty.Register(nameof(GeometryHeight), typeof(double), typeof(GeometryCreator),
                new PropertyMetadata(default(double), OnGeometryHeightChanged));

        /// <summary>
        ///     标识 GeometryWidth 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GeometryWidthProperty =
            DependencyProperty.Register(nameof(GeometryWidth), typeof(double), typeof(GeometryCreator),
                new PropertyMetadata(default(double), OnGeometryWidthChanged));

        /// <summary>
        /// 标识 Padding 依赖属性。
        /// </summary>
        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register(nameof(Padding), typeof(Thickness), typeof(GeometryCreator), new PropertyMetadata(default(Thickness), OnPaddingChanged));

        /// <summary>
        ///     标识 Result 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register(nameof(Result), typeof(Geometry), typeof(GeometryCreator),
                new PropertyMetadata(default(Geometry)));

        /// <summary>
        ///     获取或设置CornerRadius的值
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        ///     获取或设置GeometryHeight的值
        /// </summary>
        public double GeometryHeight
        {
            get => (double)GetValue(GeometryHeightProperty);
            set => SetValue(GeometryHeightProperty, value);
        }

        /// <summary>
        ///     获取或设置GeometryWidth的值
        /// </summary>
        public double GeometryWidth
        {
            get => (double)GetValue(GeometryWidthProperty);
            set => SetValue(GeometryWidthProperty, value);
        }

        /// <summary>
        /// 获取或设置Padding的值
        /// </summary>
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        /// <summary>
        ///     获取或设置Result的值
        /// </summary>
        public Geometry Result
        {
            get => (Geometry)GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        /// <summary>
        ///     CornerRadius 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">CornerRadius 属性的旧值。</param>
        /// <param name="newValue">CornerRadius 属性的新值。</param>
        protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue) => MakeGeometry();

        /// <summary>
        ///     GeometryHeight 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryHeight 属性的旧值。</param>
        /// <param name="newValue">GeometryHeight 属性的新值。</param>
        protected virtual void OnGeometryHeightChanged(double oldValue, double newValue) => MakeGeometry();

        /// <summary>
        ///     GeometryWidth 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryWidth 属性的旧值。</param>
        /// <param name="newValue">GeometryWidth 属性的新值。</param>
        protected virtual void OnGeometryWidthChanged(double oldValue, double newValue) => MakeGeometry();

        /// <summary>
        /// Padding 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Padding 属性的旧值。</param>
        /// <param name="newValue">Padding 属性的新值。</param>
        protected virtual void OnPaddingChanged(Thickness oldValue, Thickness newValue) => MakeGeometry();

        private static void OnCornerRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (CornerRadius)args.OldValue;
            var newValue = (CornerRadius)args.NewValue;
            if (oldValue == newValue)
            {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnCornerRadiusChanged(oldValue, newValue);
        }

        private static void OnGeometryHeightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
            {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnGeometryHeightChanged(oldValue, newValue);
        }

        private static void OnGeometryWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
            {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnGeometryWidthChanged(oldValue, newValue);
        }

        private static void OnPaddingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (Thickness)args.OldValue;
            var newValue = (Thickness)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as GeometryCreator;
            target?.OnPaddingChanged(oldValue, newValue);
        }

        private ArcSegment CreateArcSegment(Point point, double radius) => new ArcSegment
        {
            Point = point,
            Size = new Size(radius, radius),
            IsLargeArc = false,
            SweepDirection = SweepDirection.Clockwise
        };

        private void MakeGeometry()
        {
            var p1 = new Point(Padding.Left, Padding.Left + CornerRadius.TopLeft);
            var p2 = new Point(Padding.Left + CornerRadius.TopLeft, Padding.Top);
            var p3 = new Point(GeometryWidth - Padding.Right - CornerRadius.TopRight, Padding.Top);
            var p4 = new Point(GeometryWidth - Padding.Right, Padding.Top + CornerRadius.TopRight);
            var p5 = new Point(GeometryWidth - Padding.Right, GeometryHeight - Padding.Bottom - CornerRadius.BottomRight);
            var p6 = new Point(GeometryWidth - Padding.Right - CornerRadius.BottomRight, GeometryHeight - Padding.Bottom);
            var p7 = new Point(Padding.Left + CornerRadius.BottomLeft, GeometryHeight - Padding.Bottom);
            var p8 = new Point(Padding.Left, GeometryHeight - Padding.Bottom - CornerRadius.BottomLeft);
            var figure = new PathFigure { IsClosed = true, StartPoint = p1 };
            figure.Segments.Add(CreateArcSegment(p2, CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = p3 });
            figure.Segments.Add(CreateArcSegment(p4, CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = p5 });
            figure.Segments.Add(CreateArcSegment(p6, CornerRadius.BottomRight));
            figure.Segments.Add(new LineSegment { Point = p7 });
            figure.Segments.Add(CreateArcSegment(p8, CornerRadius.BottomLeft));
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);
            Result = pathGeometry;
        }
    }
}