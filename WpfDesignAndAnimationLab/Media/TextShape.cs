using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace WpfDesignAndAnimationLab.Media
{
    public class TextShape : Shape, IShape
    {
        

        protected sealed override Geometry DefiningGeometry
        {
            get
            {
                return this.GeometrySource.Geometry ?? Geometry.Empty;
            }
        }


        static PrimitiveShape()
        {
            Shape.StretchProperty.OverrideMetadata(typeof(PrimitiveShape), new DrawingPropertyMetadata((object)Stretch.Fill, DrawingPropertyMetadataOptions.AffectsRender));
            Shape.StrokeThicknessProperty.OverrideMetadata(typeof(PrimitiveShape), new DrawingPropertyMetadata((object)1, DrawingPropertyMetadataOptions.AffectsRender));
        }

        protected PrimitiveShape()
        {
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this.GeometrySource.UpdateGeometry(this, finalSize.Bounds()))
            {
                this.RealizeGeometry();
            }
            base.ArrangeOverride(finalSize);
            return finalSize;
        }

        protected abstract IGeometrySource CreateGeometrySource();

        public void InvalidateGeometry(InvalidateGeometryReasons reasons)
        {
            if (this.GeometrySource.InvalidateGeometry(reasons))
            {
                base.InvalidateArrange();
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(base.StrokeThickness, base.StrokeThickness);
        }

        Stretch Microsoft.Expression.Media.IGeometrySourceParameters.get_Stretch()
        {
            return base.Stretch;
        }

        Brush Microsoft.Expression.Media.IGeometrySourceParameters.get_Stroke()
        {
            return base.Stroke;
        }

        double Microsoft.Expression.Media.IGeometrySourceParameters.get_StrokeThickness()
        {
            return base.StrokeThickness;
        }

        Brush Microsoft.Expression.Media.IShape.get_Fill()
        {
            return base.Fill;
        }

        Stretch Microsoft.Expression.Media.IShape.get_Stretch()
        {
            return base.Stretch;
        }

        Brush Microsoft.Expression.Media.IShape.get_Stroke()
        {
            return base.Stroke;
        }

        double Microsoft.Expression.Media.IShape.get_StrokeThickness()
        {
            return base.StrokeThickness;
        }

        void Microsoft.Expression.Media.IShape.set_Fill(Brush brush)
        {
            base.Fill = brush;
        }

        void Microsoft.Expression.Media.IShape.set_Stretch(Stretch stretch)
        {
            base.Stretch = stretch;
        }

        void Microsoft.Expression.Media.IShape.set_Stroke(Brush brush)
        {
            base.Stroke = brush;
        }

        void Microsoft.Expression.Media.IShape.set_StrokeThickness(double num)
        {
            base.StrokeThickness = num;
        }

        private void RealizeGeometry()
        {
            if (this.RenderedGeometryChanged != null)
            {
                this.RenderedGeometryChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler RenderedGeometryChanged;
    }
}
