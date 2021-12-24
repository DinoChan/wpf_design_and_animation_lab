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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDesignAndAnimationLab.Demos.InnerShadows
{
    /// <summary>
    /// VariableSizeInnerShadowDemo.xaml 的交互逻辑
    /// </summary>
    public partial class VariableSizeInnerShadowDemo
    {
        public VariableSizeInnerShadowDemo()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ShadowElement.Margin = new Thickness(-e.NewValue);
            ShadowElement.BorderThickness = new Thickness(e.NewValue);
            (ShadowElement.Effect as DropShadowEffect).BlurRadius = e.NewValue * 2;
        }
    }
}
