using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesignAndAnimationLab.Media
{
    [Flags]
    public enum InvalidateGeometryReasons
    {
        PropertyChanged = 1,
        IsAnimated = 2,
        ChildInvalidated = 4,
        ParentInvalidated = 8,
        TemplateChanged = 16
    }
}
