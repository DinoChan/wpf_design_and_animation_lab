using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    public class NeuomorphismBoxTemplateSettings
    {
        public DropShadowEffect LightShadowEffect { get; set; }

        public DropShadowEffect DarkShadowEffect { get; set; }

        public Brush Background { get; set; }

        public NeuomorphismBoxTemplateSettings(Color color, double distance, double intensity, double blur, NeuomorphismShape shape, NeuomorphismLightSource lightSource)
        {
            Background = CreateBackground(color, shape, lightSource);

            var darkColor = ColorHelper.ColorWithLuminance(color, intensity * -1);
            var lightColor = ColorHelper.ColorWithLuminance(color, intensity);

            double lightDirection = 0;
            switch (lightSource)
            {
                case NeuomorphismLightSource.TopLeft:
                    lightDirection = 135;
                    break;
                case NeuomorphismLightSource.TopRight:
                    lightDirection = 225;
                    break;
                case NeuomorphismLightSource.BottomLeft:
                    lightDirection = 315;
                    break;
                case NeuomorphismLightSource.BottomRight:
                    lightDirection = 90;
                    break;
                default:
                    break;
            }

            var darkDirection = lightDirection - 180;

            LightShadowEffect = new DropShadowEffect { BlurRadius = blur, Color = lightColor, Direction = lightDirection, ShadowDepth = distance };
            DarkShadowEffect = new DropShadowEffect { BlurRadius = blur, Color = darkColor, Direction = darkDirection, ShadowDepth = distance };
        }



        private Brush CreateBackground(Color color, NeuomorphismShape shape, NeuomorphismLightSource lightSource)
        {
            if (shape == NeuomorphismShape.Flat || shape == NeuomorphismShape.Pressed)
                return new SolidColorBrush(color);

            var firstGradientColor = ColorHelper.ColorWithLuminance(color, shape == NeuomorphismShape.Convex ? 0.07 : -0.1);
            var secondGradientColor = ColorHelper.ColorWithLuminance(color, shape == NeuomorphismShape.Concave ? 0.07 : -0.1);
            Point startPoint, endPoint;

            switch (lightSource)
            {
                case NeuomorphismLightSource.TopLeft:
                    startPoint = new Point(0, 0);
                    endPoint = new Point(1, 1);
                    break;
                case NeuomorphismLightSource.TopRight:
                    startPoint = new Point(1, 0);
                    endPoint = new Point(0, 1);
                    break;
                case NeuomorphismLightSource.BottomLeft:
                    startPoint = new Point(0, 1);
                    endPoint = new Point(1, 0);
                    break;
                case NeuomorphismLightSource.BottomRight:
                    startPoint = new Point(1, 1);
                    endPoint = new Point(0, 0);
                    break;
                default:
                    break;
            }

            var result = new LinearGradientBrush { StartPoint = startPoint, EndPoint = endPoint };
            result.GradientStops.Add(new GradientStop(firstGradientColor, 0));
            result.GradientStops.Add(new GradientStop(secondGradientColor, 1));
            return result;
        }
    }
}
