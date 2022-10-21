using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDesignAndAnimationLab.Common;
using Color = System.Windows.Media.Color;

namespace WpfDesignAndAnimationLab.Demos.ColorWheel
{
    /// <summary>
    /// Interaction logic for ColorWheelDemo.xaml
    /// </summary>
    public partial class ColorWheelDemo
    {
        public ColorWheelDemo()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            FillWheel();
            FillSRGBWheel();
        }

        private void FillWheel()
        {
            var diameter = Convert.ToInt32(Math.Max(HsvWheel.Width, HsvWheel.Height));
            var radius = diameter / 2;
            var source = new WriteableBitmap(diameter, diameter, 96, 96, PixelFormats.Bgra32, null);
            int length = source.BackBufferStride * diameter;
            var pixels = new byte[length];
            var array = new double[diameter, diameter];
            for (var i = 0; i < diameter * diameter; i++)
            {
                var x = i % diameter;
                var y = i / diameter;
                var distance = Math.Sqrt(Math.Pow(radius - x, 2) + Math.Pow(radius - y, 2));
                var saturation = distance / radius;
                array[x, y] = saturation;
                if (saturation >= 1)
                {
                    pixels[i * 4] = 0;
                    pixels[i * 4 + 1] = 0;
                    pixels[i * 4 + 2] = 0;
                    pixels[i * 4 + 3] = 0;
                }
                else
                {
                    var distanceOfX = x - radius;
                    var distanceOfY = y - radius;

                    var theta = Math.Atan2(distanceOfY, distanceOfX);
                    if (theta < 0)
                        theta += 2 * Math.PI;

                    var hue = theta / (Math.PI * 2) * 360.0;
                    var color = ColorHelper.FromHsv(hue, saturation, 1);
                    pixels[i * 4] = color.B;
                    pixels[i * 4 + 1] = color.G;
                    pixels[i * 4 + 2] = color.R;
                    pixels[i * 4 + 3] = 255;
                }
            }
            source.WritePixels(new Int32Rect(0, 0, diameter, diameter), pixels, source.BackBufferStride, 0);
            HsvWheel.Source = source;
        }

        private void FillSRGBWheel()
        {
            var diameter = Convert.ToInt32(Math.Max(HsvWheel.Width, HsvWheel.Height));
            var radius = diameter / 2;
            var source = new WriteableBitmap(diameter, diameter, 96, 96, PixelFormats.Bgra32, null);
            int length = source.BackBufferStride * diameter;
            var pixels = new byte[length];
            var array = new double[diameter, diameter];
            for (var i = 0; i < diameter * diameter; i++)
            {
                var x = i % diameter;
                var y = i / diameter;
                var distance = Math.Sqrt(Math.Pow(radius - x, 2) + Math.Pow(radius - y, 2));
                var saturation = distance / radius;
                array[x, y] = saturation;
                if (saturation >= 1)
                {
                    pixels[i * 4] = 0;
                    pixels[i * 4 + 1] = 0;
                    pixels[i * 4 + 2] = 0;
                    pixels[i * 4 + 3] = 0;
                }
                else
                {
                    var distanceOfX = x - radius;
                    var distanceOfY = y - radius;

                    var theta = Math.Atan2(distanceOfY, distanceOfX);
                    if (theta < 0)
                        theta += 2 * Math.PI;

                    var hue = theta / (Math.PI * 2) * 360.0;
                    var color = ColorHelper.FromHsv(hue, saturation, 1);
                    color = ConvertToSRGBColor(color);
                    pixels[i * 4] = color.B;
                    pixels[i * 4 + 1] = color.G;
                    pixels[i * 4 + 2] = color.R;
                    pixels[i * 4 + 3] = 255;
                }
            }
            source.WritePixels(new Int32Rect(0, 0, diameter, diameter), pixels, source.BackBufferStride, 0);
            SRGBHsvWheel.Source = source;
        }


        private Color ConvertToSRGBColor(Color color)
        {
            var newColor = new Color();
            newColor.ScR = (float)color.R / 255;
            newColor.ScG = (float)color.G / 255;
            newColor.ScB = (float)color.B / 255;

            return newColor;
        }

    }
}
