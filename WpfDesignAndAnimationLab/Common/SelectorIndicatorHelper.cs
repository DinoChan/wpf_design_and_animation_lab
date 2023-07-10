using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Common
{
    public class SelectorIndicatorHelper : FrameworkElement
    {
        public static readonly DependencyProperty IsLeftToRightProperty =
            DependencyProperty.Register(nameof(IsLeftToRight), typeof(bool), typeof(SelectorIndicatorHelper));

        public static readonly DependencyProperty MarginLeftProperty =
            DependencyProperty.Register(nameof(MarginLeft), typeof(double), typeof(SelectorIndicatorHelper));

        public static readonly DependencyProperty MarginRightProperty =
            DependencyProperty.Register(nameof(MarginRight), typeof(double), typeof(SelectorIndicatorHelper));

        public static readonly DependencyProperty SelectorProperty =
            DependencyProperty.Register(nameof(Selector), typeof(Selector), typeof(SelectorIndicatorHelper), new PropertyMetadata(default(Selector), OnSelectorChanged));

        public bool IsLeftToRight
        {
            get => (bool)GetValue(IsLeftToRightProperty);
            set => SetValue(IsLeftToRightProperty, value);
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

        public Selector Selector
        {
            get => (Selector)GetValue(SelectorProperty);
            set => SetValue(SelectorProperty, value);
        }

        protected virtual void OnSelectorChanged(Selector oldValue, Selector newValue)
        {
            if (oldValue != null)
                newValue.SelectionChanged -= OnSelectionChanged;
            if (newValue != null)
            {
                newValue.SelectionChanged += OnSelectionChanged;
                UpdatePosition();
            }
        }

        private static void OnSelectorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (Selector)args.OldValue;
            var newValue = (Selector)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as SelectorIndicatorHelper;
            target?.OnSelectorChanged(oldValue, newValue);
        }

        private void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0)
            {
                MarginLeft = 0;
                MarginRight = 0;
                IsLeftToRight = false;
            }
            else
            {
                int oldSelectedIndex = 0;
                if (e.RemovedItems != null && e.RemovedItems.Count > 0)
                    oldSelectedIndex = Selector.Items.IndexOf(e.RemovedItems[0]);

                var newSelectedIndex = Selector.SelectedIndex;
                IsLeftToRight = newSelectedIndex > oldSelectedIndex;
                UpdatePosition();
            }
        }

        private void UpdatePosition()
        {
            var selectedObject = Selector.SelectedItem;
            var container = Selector.ItemContainerGenerator.ContainerFromItem(selectedObject) as FrameworkElement;
            var panel = VisualTreeHelper.GetParent(container) as FrameworkElement;
            var transform = container.TransformToVisual(panel);
            var transformPoint = transform.Transform(new Point(0, 0));
            MarginLeft = transformPoint.X;
            MarginRight = panel.ActualWidth - MarginLeft - container.ActualWidth; 
        }
    }
}