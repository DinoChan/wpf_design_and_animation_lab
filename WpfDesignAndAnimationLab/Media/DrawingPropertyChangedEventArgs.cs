using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesignAndAnimationLab.Media
{
    internal class DrawingPropertyChangedEventArgs : EventArgs
    {
        public bool IsAnimated
        {
            get;
            set;
        }

        public DrawingPropertyMetadata Metadata
        {
            get;
            set;
        }

        public DrawingPropertyChangedEventArgs()
        {
        }
    }
}
