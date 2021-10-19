using System;
using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Media
{
    public interface IShape
    {
        Brush Fill
        {
            get;
            set;
        }


        Geometry RenderedGeometry
        {
            get;
        }

        Stretch Stretch
        {
            get;
            set;
        }

        Brush Stroke
        {
            get;
            set;
        }

        double StrokeThickness
        {
            get;
            set;
        }

        void InvalidateGeometry(InvalidateGeometryReasons reasons);

        event EventHandler RenderedGeometryChanged;
    }
}
