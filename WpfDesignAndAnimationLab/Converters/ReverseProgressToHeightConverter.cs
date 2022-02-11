using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDesignAndAnimationLab.Converters
{
    public class ReverseProgressToHeightConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// 获取或设置TargetContentControl的值
        /// </summary>  
        public ContentControl TargetContentControl
        {
            get { return (ContentControl)GetValue(TargetContentControlProperty); }
            set { SetValue(TargetContentControlProperty, value); }
        }

        /// <summary>
        /// 标识 TargetContentControl 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TargetContentControlProperty =
            DependencyProperty.Register("TargetContentControl", typeof(ContentControl), typeof(ReverseProgressToHeightConverter), new PropertyMetadata(null));



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double == false)
                return double.NaN;

            var progress = (double)value;

            if (TargetContentControl == null)
                return double.NaN;

            if (TargetContentControl.Content is not FrameworkElement element)
                return double.NaN;

            return element.Height * (100 - progress) / 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
