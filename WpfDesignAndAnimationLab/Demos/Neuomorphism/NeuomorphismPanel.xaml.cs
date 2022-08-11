using System.Windows;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Demos.Neuomorphism
{
    /// <summary>
    /// https://neumorphism.io/
    /// </summary>
    public partial class NeuomorphismPanel
    {
        public NeuomorphismPanel()
        {
            InitializeComponent();
        }

        private void OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
                Background = new SolidColorBrush(e.NewValue.Value);
        }

        private void OnSizeValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RadiusSlider != null)
                RadiusSlider.Maximum = e.NewValue / 2;
        }
    }
}