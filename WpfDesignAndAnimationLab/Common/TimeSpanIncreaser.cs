using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDesignAndAnimationLab.Common
{
    public class TimeSpanIncreaser : Increaser<TimeSpan>
    {

        private TimeSpan _current;

        public override TimeSpan Next => Start + (_current += Step);



        public override TimeSpan Start
        {
            get { return (TimeSpan)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Start.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(TimeSpan), typeof(TimeSpanIncreaser), new PropertyMetadata(default(TimeSpan)));


    }
}
