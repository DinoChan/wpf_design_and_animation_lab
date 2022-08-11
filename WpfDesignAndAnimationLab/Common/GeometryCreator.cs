using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Common
{
    public class GeometryCreator : FrameworkElement
    {
        /// <summary>
        /// 标识 CornerRadius 依赖属性。
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GeometryCreator), new PropertyMetadata(default(CornerRadius), OnCornerRadiusChanged));

        /// <summary>
        /// 标识 GeometryHeight 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GeometryHeightProperty =
            DependencyProperty.Register(nameof(GeometryHeight), typeof(double), typeof(GeometryCreator), new PropertyMetadata(default(double), OnGeometryHeightChanged));

        /// <summary>
        /// 标识 GeometryWidth 依赖属性。
        /// </summary>
        public static readonly DependencyProperty GeometryWidthProperty =
            DependencyProperty.Register(nameof(GeometryWidth), typeof(double), typeof(GeometryCreator), new PropertyMetadata(default(double), OnGeometryWidthChanged));

        /// <summary>
        /// 标识 Result 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register(nameof(Result), typeof(Geometry), typeof(GeometryCreator), new PropertyMetadata(default(Geometry)));

        /// <summary>
        /// 获取或设置CornerRadius的值
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// 获取或设置GeometryHeight的值
        /// </summary>
        public double GeometryHeight
        {
            get => (double)GetValue(GeometryHeightProperty);
            set => SetValue(GeometryHeightProperty, value);
        }

        /// <summary>
        /// 获取或设置GeometryWidth的值
        /// </summary>
        public double GeometryWidth
        {
            get => (double)GetValue(GeometryWidthProperty);
            set => SetValue(GeometryWidthProperty, value);
        }

        /// <summary>
        /// 获取或设置Result的值
        /// </summary>
        public Geometry Result
        {
            get => (Geometry)GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        /// <summary>
        /// CornerRadius 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">CornerRadius 属性的旧值。</param>
        /// <param name="newValue">CornerRadius 属性的新值。</param>
        protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
        {
            MakeGeometry();
        }

        /// <summary>
        /// GeometryHeight 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryHeight 属性的旧值。</param>
        /// <param name="newValue">GeometryHeight 属性的新值。</param>
        protected virtual void OnGeometryHeightChanged(double oldValue, double newValue)
        {
            MakeGeometry();
        }

        /// <summary>
        /// GeometryWidth 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryWidth 属性的旧值。</param>
        /// <param name="newValue">GeometryWidth 属性的新值。</param>
        protected virtual void OnGeometryWidthChanged(double oldValue, double newValue)
        {
            MakeGeometry();
        }

        private static void OnCornerRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (CornerRadius)args.OldValue;
            var newValue = (CornerRadius)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as GeometryCreator;
            target?.OnCornerRadiusChanged(oldValue, newValue);
        }

        private static void OnGeometryHeightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as GeometryCreator;
            target?.OnGeometryHeightChanged(oldValue, newValue);
        }

        private static void OnGeometryWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as GeometryCreator;
            target?.OnGeometryWidthChanged(oldValue, newValue);
        }

        private ArcSegment CreateArcSegment(Point point, double radius)
        {
            return new ArcSegment { Point = point, Size = new Size(radius, radius), IsLargeArc = false, SweepDirection = SweepDirection.Clockwise };
        }

        private void MakeGeometry()
        {
            var figure = new PathFigure { IsClosed = true, StartPoint = new Point(0, CornerRadius.TopLeft) };
            figure.Segments.Add(CreateArcSegment(new Point(CornerRadius.TopLeft, 0), CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(GeometryWidth - CornerRadius.TopRight, 0) });
            figure.Segments.Add(CreateArcSegment(new Point(GeometryWidth, CornerRadius.TopRight), CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(GeometryWidth, GeometryHeight - CornerRadius.TopRight) });
            figure.Segments.Add(CreateArcSegment(new Point(GeometryWidth - CornerRadius.BottomRight, GeometryHeight), CornerRadius.BottomRight));
            figure.Segments.Add(new LineSegment { Point = new Point(CornerRadius.BottomLeft, GeometryHeight) });
            figure.Segments.Add(CreateArcSegment(new Point(0, GeometryHeight - CornerRadius.BottomLeft), CornerRadius.BottomLeft));
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);
            Result = pathGeometry;
        }
    }
}