using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesignAndAnimationLab.Common
{
    public class TimeSpanIncreaser : Increaser<TimeSpan>
    {

        private TimeSpan _current;

        public override TimeSpan Next => _current += Step;
    }
}
