using System;
using System.Windows.Markup;
using System.Windows.Media;
using WpfDesignAndAnimationLab.Media;

namespace WpfDesignAndAnimationLab.Extensions
{
    [MarkupExtensionReturnType(typeof(SolidColorBrush))]
    public class LightenExtension : MarkupExtension
    {
        public double Amount { get; set; }
        public SolidColorBrush Source { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SolidColorBrush(new HslColor(Source.Color).Lighten(Amount).ToRgb());
        }
    }
}