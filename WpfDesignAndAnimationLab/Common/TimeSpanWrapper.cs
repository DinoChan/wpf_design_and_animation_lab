using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
  public  class TimeSpanWrapper:ValueWrapper<TimeSpan>
    {
        
        public override TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimeSpanWrapper), new PropertyMetadata(default(TimeSpan)));
    }
}
