using System.Windows;
using System.Windows.Media;

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
            //var l= GetLength(TextPath.RenderedGeometry);
        }

        public double GetLength(Geometry geo)
        {
            var path = geo.GetFlattenedPathGeometry();

            var length = 0.0;

            foreach (var pf in path.Figures)
            {
                var start = pf.StartPoint;

                foreach (PolyLineSegment seg in pf.Segments)
                {
                    foreach (var point in seg.Points)
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
