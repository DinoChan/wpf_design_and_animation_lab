using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfDesignAndAnimationLab.Demos.WaveProgressBars
{
    /// <summary>
    /// thanks https://www.cnblogs.com/h82258652/p/16098909.html
    /// </summary>
    [TemplatePart(Name = RootTemplateName, Type = typeof(FrameworkElement))]
    public class WaveProgressBar : Control
    {
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(WaveProgressBar), new PropertyMetadata(0d, OnProgressChanged));

        private const string RootTemplateName = "Root";
        private Storyboard _progressStoryboard;

        public WaveProgressBar()
        {
            DefaultStyleKey = typeof(WaveProgressBar);
        }

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        public override void OnApplyTemplate()
        {
            var root = (FrameworkElement)GetTemplateChild(RootTemplateName);
            _progressStoryboard = root.Resources["ProgressStoryboard"] as Storyboard;

            PlayAnimation(true);
        }

        private static void OnProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (WaveProgressBar)d;
            obj.PlayAnimation(false);
        }

        private void PlayAnimation(bool isInit)
        {
            if (_progressStoryboard == null)
                return;

            var targetY = 100 * (1 - Progress);
            _progressStoryboard.Stop();
            (_progressStoryboard.Children[0] as PointAnimation).To = new Point(0, targetY);
            (_progressStoryboard.Children[1] as PointAnimation).To = new Point(35, targetY);
            (_progressStoryboard.Children[2] as PointAnimation).To = new Point(65, targetY);
            (_progressStoryboard.Children[3] as PointAnimation).To = new Point(100, targetY);
            _progressStoryboard.Begin();
        }
    }
}