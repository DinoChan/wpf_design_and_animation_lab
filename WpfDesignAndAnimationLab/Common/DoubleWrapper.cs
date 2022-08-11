using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class DoubleWrapper : ValueWrapper<double>
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(DoubleWrapper), new PropertyMetadata(default(double)));

        public override double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}