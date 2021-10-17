using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfDesignAndAnimationLab.AnimationDemos.OutlinedText
{
    /// <summary>
    /// Demo7Page.xaml 的交互逻辑
    /// </summary>
    public partial class Demo8Page : UserControl
    {
        private Dictionary<FrameworkElement, Point> _items;
        private bool _hasPoints;

        public Demo8Page()
        {
            InitializeComponent();
            _items = new Dictionary<FrameworkElement, Point>();
            SizeChanged += OnPageSizeChanged;
        }

        private void OnPageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _hasPoints = false;
        }

        private void OnItemLoaded(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (_items.ContainsKey(element) == false)
                _items.Add(element, new Point(0, 0));
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
                var k = subPoint.Y / subPoint.X;

                Debug.WriteLine(distance);
                var tempDistance = distance / 100;
                var tempY = subPoint.Y / 100;
                tempDistance = Math.Min(Math.PI, tempDistance);
                var x = 10 * Math.Sin(tempDistance);
                var y = 10 * Math.Sin(tempDistance);
                if (Math.Abs(x) < 0.0001 || Math.Abs(y) < 0.0001)
                {
                    x = 0;
                    y = 0;
                }

                item.Key.RenderTransform = new TranslateTransform(x, y);
            }
        }
    }
}
