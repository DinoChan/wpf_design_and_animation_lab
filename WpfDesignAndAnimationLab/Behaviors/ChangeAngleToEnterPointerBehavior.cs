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
    public class ChangeAngleToEnterPointerBehavior : Behavior<Ellipse>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
        }

        private void AssociatedObject_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateAngle(e);
        }
        private void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateAngle(e);
        }

        private void UpdateAngle(System.Windows.Input.MouseEventArgs e)
        {
            if (AssociatedObject == null || AssociatedObject.StrokeThickness == 0)
                return;

            AssociatedObject.RenderTransformOrigin = new Point(0.5, 0.5);
            var rotateTransform = AssociatedObject.RenderTransform as RotateTransform;
            if (rotateTransform == null)
            {
                rotateTransform = new RotateTransform();
                AssociatedObject.RenderTransform = rotateTransform;
            }

            var point = e.GetPosition(AssociatedObject.Parent as UIElement);
            var centerPoint = new Point(AssociatedObject.ActualWidth / 2, AssociatedObject.ActualHeight / 2);
            var angleOfLine = Math.Atan2(point.Y - centerPoint.Y, point.X - centerPoint.X) * 180 / Math.PI;
            rotateTransform.Angle = angleOfLine + 180;
        }
    }
}
