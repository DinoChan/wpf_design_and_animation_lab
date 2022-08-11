using System.Windows;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace WpfDesignAndAnimationLab.Behaviors
{
    public class ClipBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// 标识 ClipOuter 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ClipOuterProperty =
            DependencyProperty.Register(nameof(ClipOuter), typeof(bool), typeof(ClipBehavior), new PropertyMetadata(default(bool), OnClipOuterChanged));

        /// <summary>
        /// 标识 CornerRadius 依赖属性。
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ClipBehavior), new PropertyMetadata(default(CornerRadius), OnCornerRadiusChanged));

        /// <summary>
        /// 标识 Height 依赖属性。
        /// </summary>
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register(nameof(Height), typeof(double), typeof(ClipBehavior), new PropertyMetadata(default(double), OnHeightChanged));

        /// <summary>
        /// 标识 Width 依赖属性。
        /// </summary>
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register(nameof(Width), typeof(double), typeof(ClipBehavior), new PropertyMetadata(default(double), OnWidthChanged));

        /// <summary>
        /// 获取或设置ClipOuter的值
        /// </summary>
        public bool ClipOuter
        {
            get => (bool)GetValue(ClipOuterProperty);
            set => SetValue(ClipOuterProperty, value);
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
        /// 获取或设置Height的值
        /// </summary>
        public double Height
        {
            get => (double)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        /// <summary>
        /// 获取或设置Width的值
        /// </summary>
        public double Width
        {
            get => (double)GetValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            Clip();
        }

        /// <summary>
        /// ClipOuter 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">ClipOuter 属性的旧值。</param>
        /// <param name="newValue">ClipOuter 属性的新值。</param>
        protected virtual void OnClipOuterChanged(bool oldValue, bool newValue)
        {
            Clip();
        }

        /// <summary>
        /// CornerRadius 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">CornerRadius 属性的旧值。</param>
        /// <param name="newValue">CornerRadius 属性的新值。</param>
        protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
        {
            Clip();
        }

        /// <summary>
        /// Height 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Height 属性的旧值。</param>
        /// <param name="newValue">Height 属性的新值。</param>
        protected virtual void OnHeightChanged(double oldValue, double newValue)
        {
            Clip();
        }

        /// <summary>
        /// Width 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Width 属性的旧值。</param>
        /// <param name="newValue">Width 属性的新值。</param>
        protected virtual void OnWidthChanged(double oldValue, double newValue)
        {
            Clip();
        }

        private static void OnClipOuterChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ClipBehavior;
            target?.OnClipOuterChanged(oldValue, newValue);
        }

        private static void OnCornerRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (CornerRadius)args.OldValue;
            var newValue = (CornerRadius)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ClipBehavior;
            target?.OnCornerRadiusChanged(oldValue, newValue);
        }

        private static void OnHeightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ClipBehavior;
            target?.OnHeightChanged(oldValue, newValue);
        }

        private static void OnWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ClipBehavior;
            target?.OnWidthChanged(oldValue, newValue);
        }

        private void Clip()
        {
            if (AssociatedObject == null)
                return;

            var figure = new PathFigure { IsClosed = true, StartPoint = new Point(0, CornerRadius.TopLeft) };
            figure.Segments.Add(CreateArcSegment(new Point(CornerRadius.TopLeft, 0), CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(Width - CornerRadius.TopRight, 0) });
            figure.Segments.Add(CreateArcSegment(new Point(Width, CornerRadius.TopRight), CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(Width, Height - CornerRadius.TopRight) });
            figure.Segments.Add(CreateArcSegment(new Point(Width - CornerRadius.BottomRight, Height), CornerRadius.BottomRight));
            figure.Segments.Add(new LineSegment { Point = new Point(CornerRadius.BottomLeft, Height) });
            figure.Segments.Add(CreateArcSegment(new Point(0, Height - CornerRadius.BottomLeft), CornerRadius.BottomLeft));
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);

            if (ClipOuter)
                AssociatedObject.Clip = new CombinedGeometry(GeometryCombineMode.Xor, pathGeometry, new RectangleGeometry(new Rect(-5000, -5000, 10000, 10000)));
            else
                AssociatedObject.Clip = pathGeometry;
        }

        private ArcSegment CreateArcSegment(Point point, double radius)
        {
            return new ArcSegment { Point = point, Size = new Size(radius, radius), IsLargeArc = false, SweepDirection = SweepDirection.Clockwise };
        }
    }
}