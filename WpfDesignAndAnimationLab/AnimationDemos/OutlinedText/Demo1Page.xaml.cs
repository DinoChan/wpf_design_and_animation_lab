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

namespace WpfDesignAndAnimationLab.AnimationDemos.OutlinedText
{
    /// <summary>
    /// Demo1Page.xaml 的交互逻辑
    /// </summary>
    public partial class Demo1Page : UserControl
    {
        public Demo1Page()
        {
            InitializeComponent();
            var backColor = System.Drawing.ColorTranslator.FromHtml("#037be2");
            var forColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            img.Source = FancyText.BitmapImageFromText("测试字体，微软雅黑", new System.Drawing.Font("Microsoft YaHei", 60, System.Drawing.FontStyle.Bold), forColor, backColor, 6);
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
