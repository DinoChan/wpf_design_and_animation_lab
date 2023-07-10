using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class Switcher : FrameworkElement
    {
        /// <summary>
        /// 标识 FalseResult 依赖属性。
        /// </summary>
        public static readonly DependencyProperty FalseResultProperty =
            DependencyProperty.Register(nameof(FalseResult), typeof(object), typeof(Switcher), new PropertyMetadata(default(object), OnFalseResultChanged));

        public static readonly DependencyPropertyKey ResultPropertyKey =
                                DependencyProperty.RegisterReadOnly(nameof(Result), typeof(object), typeof(Switcher), new PropertyMetadata());
        
        public static readonly DependencyProperty ResultProperty = ResultPropertyKey.DependencyProperty;

        /// <summary>
        /// 标识 TrueResult 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TrueResultProperty =
            DependencyProperty.Register(nameof(TrueResult), typeof(object), typeof(Switcher), new PropertyMetadata(default(object), OnTrueResultChanged));

        /// <summary>
        /// 标识 Value 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(bool), typeof(Switcher), new PropertyMetadata(default(bool), OnValueChanged));

        /// <summary>
        /// 获取或设置FalseResult的值
        /// </summary>
        public object FalseResult
        {
            get => (object)GetValue(FalseResultProperty);
            set => SetValue(FalseResultProperty, value);
        }

        public object Result
        {
            get => GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        /// <summary>
        /// 获取或设置TrueResult的值
        /// </summary>
        public object TrueResult
        {
            get => (object)GetValue(TrueResultProperty);
            set => SetValue(TrueResultProperty, value);
        }

        /// <summary>
        /// 获取或设置Value的值
        /// </summary>
        public bool Value
        {
            get => (bool)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        /// <summary>
        /// FalseResult 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">FalseResult 属性的旧值。</param>
        /// <param name="newValue">FalseResult 属性的新值。</param>
        protected virtual void OnFalseResultChanged(object oldValue, object newValue)
        {
            UpdateResult();
        }

        /// <summary>
        /// TrueResult 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">TrueResult 属性的旧值。</param>
        /// <param name="newValue">TrueResult 属性的新值。</param>
        protected virtual void OnTrueResultChanged(object oldValue, object newValue)
        {
            UpdateResult();
        }

        /// <summary>
        /// Value 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Value 属性的旧值。</param>
        /// <param name="newValue">Value 属性的新值。</param>
        protected virtual void OnValueChanged(bool oldValue, bool newValue)
        {
            UpdateResult();
        }

        private static void OnFalseResultChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (object)args.OldValue;
            var newValue = (object)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as Switcher;
            target?.OnFalseResultChanged(oldValue, newValue);
        }

        private static void OnTrueResultChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (object)args.OldValue;
            var newValue = (object)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as Switcher;
            target?.OnTrueResultChanged(oldValue, newValue);
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as Switcher;
            target?.OnValueChanged(oldValue, newValue);
        }

        private void UpdateResult()
        {
            if (Value)
                SetValue(ResultPropertyKey, TrueResult);
            else
                SetValue(ResultPropertyKey, FalseResult);
        }
    }
}