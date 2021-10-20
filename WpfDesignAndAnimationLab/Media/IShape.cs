using System;
using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Media
{
    public interface IShape
    {

        void InvalidateGeometry(InvalidateGeometryReasons reasons);

    }
}
