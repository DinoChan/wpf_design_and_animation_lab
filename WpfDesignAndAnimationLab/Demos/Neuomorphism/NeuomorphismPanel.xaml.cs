﻿using System;
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

namespace WpfDesignAndAnimationLab.Demos.Neuomorphism
{
    /// <summary>
    /// NeuomorphismPanel.xaml 的交互逻辑
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
