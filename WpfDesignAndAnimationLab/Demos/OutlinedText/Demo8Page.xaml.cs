using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfDesignAndAnimationLab.Demos.OutlinedText
{
    /// <summary>
    /// Demo7Page.xaml 的交互逻辑
    /// </summary>
    public partial class Demo8Page
    {
        private readonly Dictionary<FrameworkElement, Point> _items;
        private bool _hasPoints;

        public Demo8Page()
        {
            InitializeComponent();
            _items = new Dictionary<FrameworkElement, Point>();
            SizeChanged += OnPageSizeChanged;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_hasPoints == false)
            {
                foreach (var item in _items)
                {
                    var point = item.Key.TransformToVisual(this).Transform(new Point(0, 0));
                    point.X += item.Key.ActualWidth / 2;
                    point.Y += item.Key.ActualHeight / 2;
                    _items[item.Key] = point;
                }
            }

            var position = e.GetPosition(this);

            foreach (var item in _items)
            {
                var subPoint = position - item.Value;
                var distance = subPoint.Length;
                var sinA = subPoint.Y / distance;
                var cosA = subPoint.X / distance;
                var tempDistance = distance / 100;
                tempDistance = 10 * Math.Min(Math.PI, tempDistance);
                var x = cosA * tempDistance;
                var y = sinA * tempDistance; ;
                item.Key.RenderTransform = new TranslateTransform(x, y);
            }
        }

        private void OnItemLoaded(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (_items.ContainsKey(element) == false)
                _items.Add(element, new Point(0, 0));
        }

        private void OnPageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _hasPoints = false;
        }
    }
}