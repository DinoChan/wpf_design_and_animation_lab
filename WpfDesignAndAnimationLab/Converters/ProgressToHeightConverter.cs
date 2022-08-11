using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDesignAndAnimationLab.Converters
{
    public class ProgressToHeightConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// 标识 TargetContentControl 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TargetContentControlProperty =
            DependencyProperty.Register("TargetContentControl", typeof(ContentControl), typeof(ProgressToHeightConverter), new PropertyMetadata(null));

        /// <summary>
        /// 获取或设置TargetContentControl的值
        /// </summary>
        public ContentControl TargetContentControl
        {
            get { return (ContentControl)GetValue(TargetContentControlProperty); }
            set { SetValue(TargetContentControlProperty, value); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double == false)
                return 0d;

            var progress = (double)value;

            if (TargetContentControl == null)
                return 0d;

            if (TargetContentControl.Content is not FrameworkElement element)
                return 0d;

            return element.Height * progress / 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}