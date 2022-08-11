using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfDesignAndAnimationLab.Converters
{
    public class FontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FontWeight.FromOpenTypeWeight(System.Convert.ToInt32(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}