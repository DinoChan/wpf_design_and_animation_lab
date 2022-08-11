using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Demos.TextShapes
{
    /// <summary>
    /// Demo1Page.xaml 的交互逻辑
    /// </summary>
    public partial class TextShapeDemo1Page
    {
        public TextShapeDemo1Page()
        {
            InitializeComponent();
            Loaded += Demo1Page_Loaded;
        }

        public static double GetLength(Geometry geo)
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

        private void Demo1Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetLength(TextPath.RenderedGeometry);
        }
    }
}