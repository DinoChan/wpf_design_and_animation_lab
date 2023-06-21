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

namespace WpfDesignAndAnimationLab.Demos.Wobble
{
    /// <summary>
    /// Interaction logic for ActivationDemo1.xaml
    /// </summary>
    public partial class WobbleDemo1
    {
        public WobbleDemo1()
        {
            InitializeComponent();
        }

        private void OnLeft(object sender, RoutedEventArgs e)
        {
            WobbleContentControl.Direction = Controls.Direction.Left;
            WobbleContentControl.Wobble();
        }

        private void OnUp(object sender, RoutedEventArgs e)
        {
            WobbleContentControl.Direction = Controls.Direction.Up;
            WobbleContentControl.Wobble();
        }

        private void OnRight(object sender, RoutedEventArgs e)
        {
            WobbleContentControl.Direction = Controls.Direction.Right;
            WobbleContentControl.Wobble();
        }

        private void OnDown(object sender, RoutedEventArgs e)
        {
            WobbleContentControl.Direction = Controls.Direction.Down;
            WobbleContentControl.Wobble();
        }
    }
}
