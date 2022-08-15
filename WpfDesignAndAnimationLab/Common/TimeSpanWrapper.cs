using System;
using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class TimeSpanWrapper : ValueWrapper<TimeSpan>
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimeSpanWrapper),
                new PropertyMetadata(default(TimeSpan)));

        public override TimeSpan Value
        {
            get => (TimeSpan)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}