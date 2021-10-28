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

namespace WpfDesignAndAnimationLab.Demos.FancyTexts
{
    /// <summary>
    /// FancyTextDemoPage.xaml 的交互逻辑
    /// </summary>
    public partial class FancyTextDemoPage 
    {
        public FancyTextDemoPage()
        {
            InitializeComponent();
            var backColor = System.Drawing.ColorTranslator.FromHtml("#037be2");
            var forColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            img.Source = FancyText.BitmapImageFromText("测试字体，微软雅黑", new System.Drawing.Font("Microsoft YaHei", 60, System.Drawing.FontStyle.Bold), forColor, backColor, 6);

        }
    }
}
