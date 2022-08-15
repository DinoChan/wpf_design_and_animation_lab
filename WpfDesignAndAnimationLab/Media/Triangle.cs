using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfDesignAndAnimationLab.Media
{
    public class Triangle : Shape
    {
        /// <summary>
        ///     标识 Direction 依赖属性。
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(Direction), typeof(Triangle),
                new FrameworkPropertyMetadata(Direction.Up, FrameworkPropertyMetadataOptions.AffectsMeasure));

        private Geometry _definingGeometry;

        public Triangle() => _definingGeometry = Geometry.Empty;

        /// <summary>
        ///     获取或设置Direction的值
        /// </summary>
        public Direction Direction
        {
            get => (Direction)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        protected sealed override Geometry DefiningGeometry => _definingGeometry;

        protected override Size MeasureOverride(Size availableSize)
        {
            RealizeGeometry(availableSize);
            return availableSize;
        }

        private void RealizeGeometry(Size size)
        {
            var geometry = new PathGeometry();
            var figure = new PathFigure { IsClosed = true };
            geometry.Figures.Add(figure);
            switch (Direction)
            {
                case Direction.Left:
                    figure.StartPoint = new Point(size.Width, 0);
                    var segment = new LineSegment { Point = new Point(size.Width, size.Height) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(0, size.Height / 2) };
                    figure.Segments.Add(segment);
                    break;

                case Direction.Up:
                    figure.StartPoint = new Point(size.Width / 2, 0);
                    //segment = new LineSegment { Point = new Point(ActualWidth / 2, 0) };
                    //figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(size.Width, size.Height) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(0, size.Height) };
                    figure.Segments.Add(segment);
                    break;

                case Direction.Right:
                    figure.StartPoint = new Point(0, 0);
                    segment = new LineSegment { Point = new Point(size.Width, size.Height / 2) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(0, size.Height) };
                    figure.Segments.Add(segment);
                    break;

                case Direction.Down:
                    figure.StartPoint = new Point(0, 0);
                    segment = new LineSegment { Point = new Point(size.Width, 0) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(size.Width / 2, size.Height) };
                    figure.Segments.Add(segment);
                    break;
            }

            _definingGeometry = geometry;
        }
    }
}