using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class ProgressWrapper : DependencyObject
    {
        /// <summary>
        ///     标识 Progress 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double), typeof(ProgressWrapper), new PropertyMetadata(0d));

        /// <summary>
        ///     获取或设置Progress的值
        /// </summary>
        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }
    }
}