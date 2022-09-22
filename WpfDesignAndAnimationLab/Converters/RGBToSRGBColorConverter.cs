using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Converters
{
    public class RGBToSRGBColorConverter : IValueConverter
    {
        private Color ConvertToSRGBColor(Color color)
        {
            var newColor = new Color();
            newColor.ScR = (float)color.R / 255;
            newColor.ScG = (float)color.G / 255;
            newColor.ScB = (float)color.B / 255;

            return newColor;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
                return ConvertToSRGBColor(color);

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
