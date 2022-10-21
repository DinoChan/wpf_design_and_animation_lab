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

namespace WpfDesignAndAnimationLab.Demos.TextAnimations
{
    /// <summary>
    /// https://www.cnblogs.com/coco1s/p/16808899.html
    /// </summary>
    public partial class iPhone14ProTextAnimation 
    {
        public iPhone14ProTextAnimation()
        {
            InitializeComponent();
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            MaskElement.Visibility = e.VerticalOffset > 930? Visibility.Visible: Visibility.Collapsed;
        }
    }
}
