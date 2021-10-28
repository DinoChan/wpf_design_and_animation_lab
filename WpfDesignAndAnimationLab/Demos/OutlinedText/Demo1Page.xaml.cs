using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDesignAndAnimationLab.Demos.OutlinedText
{
    /// <summary>
    /// Demo1Page.xaml 的交互逻辑
    /// </summary>
    public partial class Demo1Page 
    {
        public Demo1Page()
        {
            InitializeComponent();
            Loaded += Demo1Page_Loaded;
        }

        private void Demo1Page_Loaded(object sender, RoutedEventArgs e)
        {
           var l= GetLength(TextPath.RenderedGeometry);
        }

        public  double GetLength( Geometry geo)
        {
            PathGeometry path = geo.GetFlattenedPathGeometry();

            double length = 0.0;

            foreach (PathFigure pf in path.Figures)
            {
                Point start = pf.StartPoint;

                foreach (PolyLineSegment seg in pf.Segments)
                {
                    foreach (Point point in seg.Points)
                    {
                        length += (start - point).Length;
                        start = point;
                    }
                }
            }

            return length;
        }

      
    }
}
