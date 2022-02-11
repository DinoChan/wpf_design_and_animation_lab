using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;

namespace WpfDesignAndAnimationLab.Behaviors
{
    public class PathProgressBehavior : Behavior<UIElement>
    {

        protected override void OnAttached()
        {
            base.OnAttached();

        }

        /// <summary>
        /// 获取或设置Progress的值
        /// </summary>  
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        /// <summary>
        /// 标识 Progress 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double), typeof(PathProgressBehavior), new PropertyMetadata(0d, OnProgressChanged));

        private static void OnProgressChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as PathProgressBehavior;
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue != newValue)
                target.OnProgressChanged(oldValue, newValue);
        }


        protected virtual void OnProgressChanged(double oldValue, double newValue)
        {
            UpdateStrokeDashArray();
        }

        protected virtual double GetTotalLength(Shape shape)
        {
            var path = shape.RenderedGeometry.GetFlattenedPathGeometry();

            var length = 0.0;

            foreach (var pf in path.Figures)
            {
                var start = pf.StartPoint;

                foreach (PolyLineSegment seg in pf.Segments)
                {
                    foreach (var point in seg.Points)
                    {
                        length += (start - point).Length;
                        start = point;
                    }
                }
            }

            return length;
        }


        private void UpdateStrokeDashArray()
        {
            if (AssociatedObject is not Shape target)
                return;

            var progress = Progress;
            //if (target.ActualHeight == 0 || target.ActualWidth == 0)
            //    return;

            if (target.StrokeThickness == 0)
                return;


            var totalLength = GetTotalLength(target);
            var firstSection = progress * totalLength / 100 / target.StrokeThickness;
            if (progress == 100)
                firstSection = Math.Ceiling(firstSection);

            var result = new DoubleCollection { firstSection, double.MaxValue };
            target.StrokeDashArray = result;
        }
    }
}
