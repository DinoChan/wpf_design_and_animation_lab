using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesignAndAnimationLab.Media
{
    [Flags]
    internal enum DrawingPropertyMetadataOptions
    {
        None = 0,
        AffectsMeasure = 1,
        AffectsRender = 16
    }
}
