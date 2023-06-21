using System.Windows;
using System.Windows.Controls;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    public class ActivationContentControl : ContentControl
    {
        public ActivationContentControl()
        {
            this.DefaultStyleKey = typeof(ActivationContentControl);
            IsEnabledChanged += ActivationContentControl_IsEnabledChanged;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateVisualStates(false);
        }

        private void ActivationContentControl_IsEnabledChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            UpdateVisualStates();
        }

        private void UpdateVisualStates(bool useTransitions = true)
        {
            if (this.IsEnabled)
                VisualStateManager.GoToState(this, VisualStates.StateNormal, useTransitions);
            else
                VisualStateManager.GoToState(this, VisualStates.StateDisabled, useTransitions);
        }
    }
}