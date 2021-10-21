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
using WpfDesignAndAnimationLab.Infrastructure;

namespace WpfDesignAndAnimationLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var exampleDefinition = DemoItemsControl.SelectedItem as ExampleDefinition;
            if (exampleDefinition == null)
                return;

            var container = new DemoContainer(exampleDefinition);
            DemoContentControl.Content = container;
        }
    }
}
