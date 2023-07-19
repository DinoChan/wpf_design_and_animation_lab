using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    public class SelectorIndicator : ContentControl
    {
        /// <summary>
        /// 标识 IndicatorVisibility 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IndicatorVisibilityProperty =
            DependencyProperty.Register(nameof(IndicatorVisibility), typeof(Visibility), typeof(SelectorIndicator), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty IsLeftToRightProperty =
                   DependencyProperty.Register(nameof(IsLeftToRight), typeof(bool), typeof(SelectorIndicator));

        /// <summary>
        /// 标识 IsStoryboardEnabled 依赖属性。
        /// </summary>
        public static readonly DependencyProperty IsStoryboardEnabledProperty =
            DependencyProperty.Register(nameof(IsStoryboardEnabled), typeof(bool), typeof(SelectorIndicator), new PropertyMetadata(true));

        public static readonly DependencyProperty MarginLeftProperty =
                    DependencyProperty.Register(nameof(MarginLeft), typeof(double), typeof(SelectorIndicator));

        public static readonly DependencyProperty MarginRightProperty =
            DependencyProperty.Register(nameof(MarginRight), typeof(double), typeof(SelectorIndicator));

        private int currentIndex;

        private List<RadioButton> radioButtons;

        static SelectorIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorIndicator), new FrameworkPropertyMetadata(typeof(SelectorIndicator)));
        }

        public SelectorIndicator()
        {
            Loaded += SelectorIndicator_Loaded;
            SizeChanged += SelectorIndicator_SizeChanged;
        }

        /// <summary>
        /// 获取或设置IndicatorVisibility的值
        /// </summary>
        public Visibility IndicatorVisibility
        {
            get => (Visibility)GetValue(IndicatorVisibilityProperty);
            set => SetValue(IndicatorVisibilityProperty, value);
        }

        public bool IsLeftToRight
        {
            get => (bool)GetValue(IsLeftToRightProperty);
            set => SetValue(IsLeftToRightProperty, value);
        }

        /// <summary>
        /// 获取或设置IsStoryboardEnabled的值
        /// </summary>
        public bool IsStoryboardEnabled
        {
            get => (bool)GetValue(IsStoryboardEnabledProperty);
            set => SetValue(IsStoryboardEnabledProperty, value);
        }

        public double MarginLeft
        {
            get => (double)GetValue(MarginLeftProperty);
            set => SetValue(MarginLeftProperty, value);
        }

        public double MarginRight
        {
            get => (double)GetValue(MarginRightProperty);
            set => SetValue(MarginRightProperty, value);
        }

        private void AttachButtons()
        {
            if (radioButtons != null && radioButtons.Count > 0)
            {
                foreach (var button in radioButtons)
                {
                    button.Checked -= Button_Checked;
                }
            }

            var buttons = VisualTreeHelperEx.GetVisualDescendants(this).OfType<RadioButton>().OrderBy(r => r.TabIndex);
            foreach (var button in buttons)
            {
                button.Checked += Button_Checked;
            }

            radioButtons = buttons.ToList();
            UpdateIndicator();
        }

        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            UpdateIndicator();
        }

        private void SelectorIndicator_Loaded(object sender, RoutedEventArgs e)
        {
            IsStoryboardEnabled = false;
            AttachButtons();
            IsStoryboardEnabled = true;
        }

        private void SelectorIndicator_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            IsStoryboardEnabled = false;
            AttachButtons();
            IsStoryboardEnabled = true;
        }

        private void UpdateIndicator()
        {
            var selectedButton = radioButtons.FirstOrDefault(b => b.IsChecked == true);
            if (selectedButton == null || selectedButton.Visibility == Visibility.Collapsed)
            {
                IndicatorVisibility = Visibility.Collapsed;
                return;
            }

            IndicatorVisibility = Visibility.Visible;
            var newIndex = radioButtons.IndexOf(selectedButton);

            IsLeftToRight = newIndex > currentIndex;
            var transform = selectedButton.TransformToVisual(this);
            var transformPoint = transform.Transform(new Point(0, 0));
            MarginLeft = transformPoint.X;
            MarginRight = ActualWidth - MarginLeft - selectedButton.ActualWidth;
            currentIndex = newIndex;
        }
    }
}