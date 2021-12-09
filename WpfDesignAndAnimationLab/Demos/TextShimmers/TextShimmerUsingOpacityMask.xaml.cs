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
using System.Windows.Media.Animation;
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
            brush.GradientStops.Add(new GradientStop(Color.FromArgb(100, 0, 0, 0), .5));
            brush.GradientStops.Add(new GradientStop(Color.FromArgb(34, 0, 0, 0), 1));

            var centerH = TextBlock.ActualHeight / 2;

            TextBlock.OpacityMask = brush;

            var storyboard = new Storyboard();
            var centerAnimation = new PointAnimation
            {
                From = new Point(-centerH * 6, centerH),
                To = new Point(centerH * 6, centerH),
                Duration = TimeSpan.FromSeconds(3.3)
            };

            Storyboard.SetTarget(centerAnimation, brush);
            Storyboard.SetTargetProperty(centerAnimation, new PropertyPath(RadialGradientBrush.CenterProperty));

            var gradientOriginAnimation = new PointAnimation
            {
                From = new Point(-centerH * 6, centerH),
                To = new Point(centerH * 6, centerH),
                Duration = TimeSpan.FromSeconds(3.3)
            };

            Storyboard.SetTarget(gradientOriginAnimation, brush);
            Storyboard.SetTargetProperty(gradientOriginAnimation, new PropertyPath(RadialGradientBrush.GradientOriginProperty));

            storyboard.Children.Add(centerAnimation);
            storyboard.Children.Add(gradientOriginAnimation);
            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.Begin();
        }
    }
}
