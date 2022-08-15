using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class DoubleIncreaser : Increaser<double>
    {
        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(double), typeof(DoubleIncreaser),
                new PropertyMetadata(default(double)));

        private double _current;

        public override double Next
        {
            get
            {
                var result = Start + _current;
                _current += Step;
                return result;
            }
        }

        public override double Start
        {
            get => (double)GetValue(StartProperty);
            set => SetValue(StartProperty, value);
        }
    }
}