using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace WpfDesignAndAnimationLab.Behaviors
{
    public class ProgressToHeightBehavior : Behavior<FrameworkElement>
    {


        /// <summary>
        /// 获取或设置BasedElement的值
        /// </summary>
        public FrameworkElement BasedElement
        {
            get => (FrameworkElement)GetValue(BasedElementProperty);
            set => SetValue(BasedElementProperty, value);
        }

        /// <summary>
        /// 标识 BasedElement 依赖属性。
        /// </summary>
        public static readonly DependencyProperty BasedElementProperty =
            DependencyProperty.Register(nameof(BasedElement), typeof(FrameworkElement), typeof(ProgressToHeightBehavior), new PropertyMetadata(default(FrameworkElement), OnBasedElementChanged));

        private static void OnBasedElementChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (FrameworkElement)args.OldValue;
            var newValue = (FrameworkElement)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ProgressToHeightBehavior;
            target?.OnBasedElementChanged(oldValue, newValue);
        }

        /// <summary>
        /// BasedElement 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">BasedElement 属性的旧值。</param>
        /// <param name="newValue">BasedElement 属性的新值。</param>
        protected virtual void OnBasedElementChanged(FrameworkElement oldValue, FrameworkElement newValue)
        {
            ChangeAssociatedObjectHeight();
            if (newValue != null)
                newValue.SizeChanged += (s, e) => ChangeAssociatedObjectHeight();
        }



        /// <summary>
        /// 获取或设置Progress的值
        /// </summary>
        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        /// <summary>
        /// 标识 Progress 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register(nameof(Progress), typeof(double), typeof(ProgressToHeightBehavior), new PropertyMetadata(default(double), OnProgressChanged));

        private static void OnProgressChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ProgressToHeightBehavior;
            target?.OnProgressChanged(oldValue, newValue);
        }

        /// <summary>
        /// Progress 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Progress 属性的旧值。</param>
        /// <param name="newValue">Progress 属性的新值。</param>
        protected virtual void OnProgressChanged(double oldValue, double newValue)
        {
            ChangeAssociatedObjectHeight();
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            ChangeAssociatedObjectHeight();
        }

        private void ChangeAssociatedObjectHeight()
        {
            if (AssociatedObject == null || BasedElement == null)
                return;

            AssociatedObject.Height = BasedElement.ActualHeight * Progress;
        }
    }
}
