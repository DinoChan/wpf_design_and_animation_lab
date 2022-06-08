using System;
using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class DurationIncreaser : Increaser<Duration>
    {
        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(Duration), typeof(DurationIncreaser), new PropertyMetadata(new Duration(TimeSpan.Zero)));

        private Duration _current = new Duration(TimeSpan.Zero);

        public override Duration Next
        {
            get
            {
                var result = Start + _current;
                _current += Step;
                return result;
            }
        }

        public override Duration Start
        {
            get { return (Duration)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
    }
}
