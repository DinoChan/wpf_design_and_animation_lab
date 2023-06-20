using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ActivationContentControl_IsEnabledChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            UpdateVisualStates();
        }

        private void UpdateVisualStates(bool useTransitions=true)
        {
            if (this.IsEnabled)
                VisualStateManager.GoToState(this, VisualStates.StateNormal, useTransitions);
            else
                VisualStateManager.GoToState(this, VisualStates.StateDisabled, useTransitions);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateVisualStates(false);
        }
    }
}
