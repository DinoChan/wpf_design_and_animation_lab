using System.Windows;
using System.Windows.Media.Effects;

namespace WpfDesignAndAnimationLab.Demos.InnerShadows
{
    /// <summary>
    ///     VariableSizeInnerShadowDemo.xaml 的交互逻辑
    /// </summary>
    public partial class VariableSizeInnerShadowDemo
    {
        public VariableSizeInnerShadowDemo() => InitializeComponent();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ShadowElement.Margin = new Thickness(-e.NewValue);
            ShadowElement.BorderThickness = new Thickness(e.NewValue);
            (ShadowElement.Effect as DropShadowEffect).BlurRadius = e.NewValue * 2;
        }
    }
}