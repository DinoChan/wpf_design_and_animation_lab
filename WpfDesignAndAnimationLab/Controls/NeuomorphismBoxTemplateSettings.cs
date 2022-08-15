using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using WpfDesignAndAnimationLab.Common;

namespace WpfDesignAndAnimationLab.Controls
{
    public class NeuomorphismBoxTemplateSettings
    {
        public NeuomorphismBoxTemplateSettings(Color color, double distance, double intensity, double blur,
            NeuomorphismShape shape, NeuomorphismLightSource lightSource)
        {
            Background = CreateBackground(color, shape, lightSource);

            var darkColor = ColorHelper.ColorWithLuminance(color, intensity * -1);
            var lightColor = ColorHelper.ColorWithLuminance(color, intensity);

            var newDarkColor = new Color();
            newDarkColor.ScR = darkColor.R;
            newDarkColor.ScG = darkColor.G;
            newDarkColor.ScB = darkColor.B;

            var newLightColor = new Color();
            newLightColor.ScR = lightColor.R;
            newLightColor.ScG = lightColor.G;
            newLightColor.ScB = lightColor.B;

            double lightDirection = 0;
            switch (lightSource)
            {
                case NeuomorphismLightSource.TopLeft:
                    lightDirection = 135;
                    break;

                case NeuomorphismLightSource.BottomLeft:
                    lightDirection = 225;
                    break;

                case NeuomorphismLightSource.BottomRight:
                    lightDirection = 315;
                    break;

                case NeuomorphismLightSource.TopRight:
                    lightDirection = 90;
                    break;
            }

            var darkDirection = lightDirection - 180;

            LightShadowEffect = new DropShadowEffect
            {
                BlurRadius = blur,
                Color = ConvertToSRGBColor(lightColor),
                Direction = lightDirection,
                ShadowDepth = distance
            };
            DarkShadowEffect = new DropShadowEffect
            {
                BlurRadius = blur,
                Color = ConvertToSRGBColor(darkColor),
                Direction = darkDirection,
                ShadowDepth = distance
            };
        }

        public Brush Background { get; set; }
        public DropShadowEffect DarkShadowEffect { get; set; }
        public DropShadowEffect LightShadowEffect { get; set; }

        private Color ConvertToSRGBColor(Color color)
        {
            var newColor = new Color();
            newColor.ScR = (float)color.R / 255;
            newColor.ScG = (float)color.G / 255;
            newColor.ScB = (float)color.B / 255;

            return newColor;
        }

        private Brush CreateBackground(Color color, NeuomorphismShape shape, NeuomorphismLightSource lightSource)
        {
            if (shape == NeuomorphismShape.Flat || shape == NeuomorphismShape.Pressed)
            {
                return new SolidColorBrush(color);
            }

            var firstGradientColor =
                ColorHelper.ColorWithLuminance(color, shape == NeuomorphismShape.Convex ? 0.07 : -0.1);
            var secondGradientColor =
                ColorHelper.ColorWithLuminance(color, shape == NeuomorphismShape.Concave ? 0.07 : -0.1);
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
            }

            var result = new LinearGradientBrush { StartPoint = startPoint, EndPoint = endPoint };
            result.GradientStops.Add(new GradientStop(firstGradientColor, 0));
            result.GradientStops.Add(new GradientStop(secondGradientColor, 1));
            return result;
        }
    }
}