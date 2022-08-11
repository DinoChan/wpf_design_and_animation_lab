using System.Windows;

namespace WpfDesignAndAnimationLab.Media
{
    public class ShapeStrokeHelper : DependencyObject
    {
        /// <summary>
        /// 标识 AttachedShape 依赖属性。
        /// </summary>
        public static readonly DependencyProperty AttachedShapeProperty =
            DependencyProperty.Register(nameof(AttachedShape), typeof(DependencyObject), typeof(ShapeStrokeHelper), new PropertyMetadata(default(DependencyObject), OnAttachedShapeChanged));

        /// <summary>
        /// 获取或设置AttachedShape的值
        /// </summary>
        public DependencyObject AttachedShape
        {
            get => (DependencyObject)GetValue(AttachedShapeProperty);
            set => SetValue(AttachedShapeProperty, value);
        }

        /// <summary>
        /// AttachedShape 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">AttachedShape 属性的旧值。</param>
        /// <param name="newValue">AttachedShape 属性的新值。</param>
        protected virtual void OnAttachedShapeChanged(DependencyObject oldValue, DependencyObject newValue)
        {
        }

        private static void OnAttachedShapeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (DependencyObject)args.OldValue;
            var newValue = (DependencyObject)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as ShapeStrokeHelper;
            target?.OnAttachedShapeChanged(oldValue, newValue);
        }
    }
}