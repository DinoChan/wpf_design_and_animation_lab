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

namespace WpfDesignAndAnimationLab.Demos.NintendoSwitchLoadings
{
    /// <summary>
    /// NintendoEShopLoadingRow.xaml 的交互逻辑
    /// </summary>
    public partial class NintendoEShopLoadingRow : UserControl
    {
        public NintendoEShopLoadingRow()
        {
            InitializeComponent();
            Loaded += NintendoEShopLoadingRow_Loaded;
        }

        private async void NintendoEShopLoadingRow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2) + Delay);
            (this.Resources["Storyboard"] as Storyboard).Begin();
        }



        public TimeSpan Delay
        {
            get { return (TimeSpan)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(TimeSpan), typeof(NintendoEShopLoadingRow), new PropertyMetadata(default(TimeSpan)));


    }
}
