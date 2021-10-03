using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfDesignAndAnimationLab.Controls
{
    public class Triangle : Path
    {
        /// <summary>
        ///     标识 Direction 依赖属性。
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(Direction), typeof(Triangle), new PropertyMetadata(Direction.Up, OnDirectionChanged));



        /// <summary>
        ///     获取或设置Direction的值
        /// </summary>
        public Direction Direction
        {
            get { return (Direction)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        private static void OnDirectionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as Triangle;
            var oldValue = (Direction)args.OldValue;
            var newValue = (Direction)args.NewValue;
            if (oldValue != newValue)
                target.OnDirectionChanged(oldValue, newValue);
        }

        protected virtual void OnDirectionChanged(Direction oldValue, Direction newValue)
        {
            InvalidateGeometry();
        }

        public Triangle()
        {

        }

        private bool _realizeGeometryScheduled;
        private Size _orginalSize;
        private Direction _orginalDirection;

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_realizeGeometryScheduled == false && _orginalSize != finalSize)
            {
                _realizeGeometryScheduled = true;
                LayoutUpdated += OnTriangleLayoutUpdated;
                _orginalSize = finalSize;
            }
            base.ArrangeOverride(finalSize);
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(base.StrokeThickness, base.StrokeThickness);
        }

        public void InvalidateGeometry()
        {
            InvalidateArrange();
            if (_realizeGeometryScheduled == false && _orginalDirection != Direction)
            {
                _realizeGeometryScheduled = true;
                LayoutUpdated += OnTriangleLayoutUpdated;
            }
        }

        private void OnTriangleLayoutUpdated(object sender, object e)
        {
            _realizeGeometryScheduled = false;
            LayoutUpdated -= OnTriangleLayoutUpdated;
            RealizeGeometry();
        }

        private void RealizeGeometry()
        {
            var geometry = new PathGeometry();
            var figure = new PathFigure { IsClosed = true };
            geometry.Figures.Add(figure);
            switch (Direction)
            {
                case Direction.Left:
                    figure.StartPoint = new Point(ActualWidth, 0);
                    var segment = new LineSegment { Point = new Point(ActualWidth, ActualHeight) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(0, ActualHeight / 2) };
                    figure.Segments.Add(segment);
                    break;
                case Direction.Up:
                    figure.StartPoint = new Point(0, ActualHeight);
                    segment = new LineSegment { Point = new Point(ActualWidth / 2, 0) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(ActualWidth, ActualHeight) };
                    figure.Segments.Add(segment);
                    break;
                case Direction.Right:
                    figure.StartPoint = new Point(0, 0);
                    segment = new LineSegment { Point = new Point(ActualWidth, ActualHeight / 2) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(0, ActualHeight) };
                    figure.Segments.Add(segment);
                    break;
                case Direction.Down:
                    figure.StartPoint = new Point(0, 0);
                    segment = new LineSegment { Point = new Point(ActualWidth, 0) };
                    figure.Segments.Add(segment);
                    segment = new LineSegment { Point = new Point(ActualWidth / 2, ActualHeight) };
                    figure.Segments.Add(segment);
                    break;
            }
            _orginalDirection = Direction;
            Data = geometry;
        }

    }
}
