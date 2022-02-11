using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfDesignAndAnimationLab.Infrastructure
{
    /// <summary>
    /// DemoContainer.xaml 的交互逻辑
    /// </summary>
    public partial class DemoContainer : UserControl
    {
        public DemoContainer(ExampleDefinition exampleDefinition)
        {
            InitializeComponent();
            ExampleDefinition = exampleDefinition;
            TitleElement.Text = exampleDefinition.Name;
            DemoItemsElement.ItemsSource = exampleDefinition.Items;
            DemoItemsElement.SelectedItem = exampleDefinition.Items.FirstOrDefault();
            if (exampleDefinition.Items.Count() == 1)
            {
                ItemsSperator.Visibility = Visibility.Collapsed;
                DemoItemsElement.Visibility = Visibility.Collapsed;
            }
        }

        public ExampleDefinition ExampleDefinition { get; }

        private void DemoItemsElement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = DemoItemsElement.SelectedItem as ExampleDefinitionItem;
            if (item == null)
                return;

            var demo = Activator.CreateInstance(item.Control);
            ContentControl.Content = demo;
        }
    }
}
