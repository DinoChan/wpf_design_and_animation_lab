using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WpfDesignAndAnimationLab.Media;

namespace WpfDesignAndAnimationLab.Converters
{
    public class LightenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not SolidColorBrush brush)
                return value;

            var amount = System.Convert.ToDouble(parameter);

            return new SolidColorBrush(new HslColor(brush.Color).Lighten(amount).ToRgb());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}