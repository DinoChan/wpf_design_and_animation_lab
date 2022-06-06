using System.Windows;
using System.Windows.Media.Animation;

namespace WpfDesignAndAnimationLab.Common
{
    public class AnimatePointWrapper : FrameworkElement
    {
        /// <summary>
        /// 标识 Animation 依赖属性。
        /// </summary>
        public static readonly DependencyProperty AnimationProperty =
            DependencyProperty.Register(nameof(Animation), typeof(PointAnimation), typeof(AnimatePointWrapper), new PropertyMetadata(default(PointAnimation), OnAnimationChanged));

        /// <summary>
        /// 标识 Current 依赖属性。
        /// </summary>
        public static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register(nameof(Current), typeof(Point), typeof(AnimatePointWrapper), new PropertyMetadata(default(Point), OnCurrentChanged));

        /// <summary>
        /// 标识 MultipleX 依赖属性。
        /// </summary>
        public static readonly DependencyProperty MultipleXProperty =
            DependencyProperty.Register(nameof(MultipleX), typeof(double), typeof(AnimatePointWrapper), new PropertyMetadata(1d, OnMultipleXChanged));

        /// <summary>
        /// 标识 MultipleY 依赖属性。
        /// </summary>
        public static readonly DependencyProperty MultipleYProperty =
            DependencyProperty.Register(nameof(MultipleY), typeof(double), typeof(AnimatePointWrapper), new PropertyMetadata(1d, OnMultipleYChanged));

        /// <summary>
        /// 标识 TargetX 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TargetXProperty =
            DependencyProperty.Register(nameof(TargetX), typeof(double), typeof(AnimatePointWrapper), new PropertyMetadata(default(double), OnTargetXChanged));

        /// <summary>
        /// 标识 TargetY 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TargetYProperty =
            DependencyProperty.Register(nameof(TargetY), typeof(double), typeof(AnimatePointWrapper), new PropertyMetadata(default(double), OnTargetYChanged));

        private PointAnimation _coreAnimation;

        private Storyboard _storyboard = new Storyboard();

        /// <summary>
        /// 获取或设置Animation的值
        /// </summary>
        public PointAnimation Animation
        {
            get => (PointAnimation)GetValue(AnimationProperty);
            set => SetValue(AnimationProperty, value);
        }

        /// <summary>
        /// 获取或设置Current的值
        /// </summary>
        public Point Current
        {
            get => (Point)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }

        public AnimatePointWrapper()
        {
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) => _storyboard.SkipToFill();

        /// <summary>
        /// 获取或设置MultipleX的值
        /// </summary>
        public double MultipleX
        {
            get => (double)GetValue(MultipleXProperty);
            set => SetValue(MultipleXProperty, value);
        }
        /// <summary>
        /// 获取或设置MultipleY的值
        /// </summary>
        public double MultipleY
        {
            get => (double)GetValue(MultipleYProperty);
            set => SetValue(MultipleYProperty, value);
        }

        /// <summary>
        /// 获取或设置TargetX的值
        /// </summary>
        public double TargetX
        {
            get => (double)GetValue(TargetXProperty);
            set => SetValue(TargetXProperty, value);
        }

        /// <summary>
        /// 获取或设置TargetY的值
        /// </summary>
        public double TargetY
        {
            get => (double)GetValue(TargetYProperty);
            set => SetValue(TargetYProperty, value);
        }

   

        /// <summary>
        /// Animation 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Animation 属性的旧值。</param>
        /// <param name="newValue">Animation 属性的新值。</param>
        protected virtual void OnAnimationChanged(PointAnimation oldValue, PointAnimation newValue)
        {
            _coreAnimation = newValue.Clone();
            _storyboard.Children.Clear();
            Storyboard.SetTarget(_coreAnimation, this);
            Storyboard.SetTargetProperty(_coreAnimation, new PropertyPath(CurrentProperty));

            _storyboard.Children.Add(_coreAnimation);
        }

        /// <summary>
        /// Current 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Current 属性的旧值。</param>
        /// <param name="newValue">Current 属性的新值。</param>
        protected virtual void OnCurrentChanged(Point oldValue, Point newValue)
        {
        }


        /// <summary>
        /// MultipleX 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">MultipleX 属性的旧值。</param>
        /// <param name="newValue">MultipleX 属性的新值。</param>
        protected virtual void OnMultipleXChanged(double oldValue, double newValue)
        {
         
        }

        /// <summary>
        /// MultipleY 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">MultipleY 属性的旧值。</param>
        /// <param name="newValue">MultipleY 属性的新值。</param>
        protected virtual void OnMultipleYChanged(double oldValue, double newValue)
        {
        }

     
        protected virtual void OnTargetChanged()
        {
            _storyboard.Stop();
            if (_coreAnimation != null)
                _coreAnimation.To = new Point(TargetX * MultipleX, TargetY * MultipleY);

            _storyboard.Begin();
        }

        /// <summary>
        /// TargetX 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">TargetX 属性的旧值。</param>
        /// <param name="newValue">TargetX 属性的新值。</param>
        protected virtual void OnTargetXChanged(double oldValue, double newValue)
        {
            OnTargetChanged();
        }

        /// <summary>
        /// TargetY 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">TargetY 属性的旧值。</param>
        /// <param name="newValue">TargetY 属性的新值。</param>
        protected virtual void OnTargetYChanged(double oldValue, double newValue)
        {
            OnTargetChanged();
        }

        private static void OnAnimationChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (PointAnimation)args.OldValue;
            var newValue = (PointAnimation)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnAnimationChanged(oldValue, newValue);
        }

        private static void OnCurrentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (Point)args.OldValue;
            var newValue = (Point)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnCurrentChanged(oldValue, newValue);
        }

        private static void OnMultipleXChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnMultipleXChanged(oldValue, newValue);
        }
        private static void OnMultipleYChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnMultipleYChanged(oldValue, newValue);
        }
        private static void OnTargetXChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnTargetXChanged(oldValue, newValue);
        }
        private static void OnTargetYChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as AnimatePointWrapper;
            target?.OnTargetYChanged(oldValue, newValue);
        }
    }
}
