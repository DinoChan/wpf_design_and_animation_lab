using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfDesignAndAnimationLab.Demos.NintendoSwitchLoadings
{
    /// <summary>
    /// NintendoEShopLoadingRow.xaml 的交互逻辑
    /// </summary>
    public partial class NintendoEShopLoadingRowUsingEffect : UserControl
    {
        // Using a DependencyProperty as the backing store for Delay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(TimeSpan), typeof(NintendoEShopLoadingRowUsingEffect), new PropertyMetadata(default(TimeSpan)));

        public NintendoEShopLoadingRowUsingEffect()
        {
            InitializeComponent();
            Loaded += NintendoEShopLoadingRow_Loaded;
        }

        public TimeSpan Delay
        {
            get { return (TimeSpan)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        private async void NintendoEShopLoadingRow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2) + Delay);
            (Resources["Storyboard"] as Storyboard).Begin();
        }
    }
}