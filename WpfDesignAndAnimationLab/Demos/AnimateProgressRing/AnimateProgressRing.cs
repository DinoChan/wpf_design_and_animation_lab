using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Demos.AnimateProgressRing
{
    public class AnimateProgressRing : RangeBase
    {
        private Storyboard _progressStoryboard;
        private ProgressWrapper _progressWrapper;

        public AnimateProgressRing()
        {
            this.DefaultStyleKey = typeof(AnimateProgressRing);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var root = GetTemplateChild("Root") as FrameworkElement;
            if (root != null)
            {
                if (root.Resources.Contains("ProgressStoryboard"))
                {
                    _progressStoryboard = root.Resources["ProgressStoryboard"] as Storyboard;
                }

                if (root.Resources.Contains("ProgressWrapper"))
                {
                    _progressWrapper = root.Resources["ProgressWrapper"] as ProgressWrapper;
                }
            }
            UpdateUI(false);
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            UpdateUI();
        }

        private void UpdateUI(bool usingStoryboard = true)
        {
            var progress = (Value - Minimum) / (Maximum - Minimum) * 100;
            if (usingStoryboard && _progressStoryboard != null)
            {
                _progressStoryboard.Stop();
                (_progressStoryboard.Children[0] as DoubleAnimation).To = progress;
                _progressStoryboard.Begin();
            }
            else if (_progressWrapper != null)
                _progressWrapper.Progress = progress;
        }
    }
}
