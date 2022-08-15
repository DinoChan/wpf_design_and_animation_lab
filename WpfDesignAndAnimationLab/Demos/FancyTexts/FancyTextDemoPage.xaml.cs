using System.Drawing;

namespace WpfDesignAndAnimationLab.Demos.FancyTexts
{
    /// <summary>
    ///     FancyTextDemoPage.xaml 的交互逻辑
    /// </summary>
    public partial class FancyTextDemoPage
    {
        public FancyTextDemoPage()
        {
            InitializeComponent();
            var backColor = ColorTranslator.FromHtml("#037be2");
            var forColor = ColorTranslator.FromHtml("#ffffff");
            img.Source = FancyText.BitmapImageFromText("测试字体，微软雅黑",
                new Font("Microsoft YaHei", 60, System.Drawing.FontStyle.Bold), forColor, backColor, 6);
        }
    }
}