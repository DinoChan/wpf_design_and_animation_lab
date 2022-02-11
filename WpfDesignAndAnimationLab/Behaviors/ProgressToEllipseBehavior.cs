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
    public class ProgressToEllipseBehavior : Behavior<Ellipse>
    {
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
            DependencyProperty.Register("Progress", typeof(double), typeof(ProgressToEllipseBehavior), new PropertyMetadata(0d, OnProgressChanged));

        private static void OnProgressChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as ProgressToEllipseBehavior;
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue != newValue)
                target.OnProgressChanged(oldValue, newValue);
        }


        protected virtual void OnProgressChanged(double oldValue, double newValue)
        {
            UpdateStrokeDashArray();
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            UpdateStrokeDashArray();
        }

        protected virtual double GetTotalLength()
        {
            if (AssociatedObject == null)
                return 0;

            return (AssociatedObject.ActualHeight - AssociatedObject.StrokeThickness) * Math.PI;
        }


        private void UpdateStrokeDashArray()
        {
            if (AssociatedObject == null || AssociatedObject.StrokeThickness == 0)
                return;

            //if (target.ActualHeight == 0 || target.ActualWidth == 0)
            //    return;

            var totalLength = GetTotalLength();
            totalLength /= AssociatedObject.StrokeThickness;
            var thirdSection = Progress * totalLength / 100;
            var secondSection = (totalLength - thirdSection) / 2;
            var result = new DoubleCollection { 0, secondSection, thirdSection, double.MaxValue };
            AssociatedObject.StrokeDashArray = result;
        }


    }
}
