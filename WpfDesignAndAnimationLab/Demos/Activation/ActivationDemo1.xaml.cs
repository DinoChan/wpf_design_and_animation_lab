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

namespace WpfDesignAndAnimationLab.Demos.Activation
{
    /// <summary>
    /// Interaction logic for ActivationDemo1.xaml
    /// </summary>
    public partial class ActivationDemo1 
    {
        public ActivationDemo1()
        {
            InitializeComponent();
        }

        private void DisableButton(object sender, RoutedEventArgs e)
        {
            ButtonElement.IsEnabled = false;
        }

        private void EnableButton(object sender, RoutedEventArgs e)
        {
            ButtonElement.IsEnabled = true;
        }
    }
}
