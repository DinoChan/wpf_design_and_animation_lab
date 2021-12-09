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

namespace WpfDesignAndAnimationLab.Demos.TextShimmers
{
    /// <summary>
    /// TextShimmerUsingOpacityMask.xaml 的交互逻辑
    /// </summary>
    public partial class TextShimmerUsingOpacityMask
    {
        public TextShimmerUsingOpacityMask()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var brush = new RadialGradientBrush
            {
                RadiusX = TextBlock.ActualHeight * 2.2,
                RadiusY = TextBlock.ActualHeight * 2.2,
                MappingMode = BrushMappingMode.Absolute
            };

            brush.GradientStops.Add(new GradientStop(Colors.Black, 0));
            brush.GradientStops.Add(new GradientStop(Color.FromArgb(100,0,0,0),.5));
            brush.GradientStops.Add(new GradientStop(Color.FromArgb(34, 0, 0, 0), 1));
        }
    }
}
