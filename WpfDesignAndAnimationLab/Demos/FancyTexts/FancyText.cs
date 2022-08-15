using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace WpfDesignAndAnimationLab.Demos.FancyTexts
{
    /// <summary>
    ///     https://www.cnblogs.com/xunyou/p/11596220.html
    /// </summary>
    public class FancyText
    {
        /// <summary>
        ///     文本转图片
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="fnt"></param>
        /// <param name="clrFore"></param>
        /// <param name="clrBack"></param>
        /// <param name="blurAmount"></param>
        /// <returns></returns>
        public static BitmapImage BitmapImageFromText(string strText, Font fnt, Color clrFore, Color clrBack,
            int blurAmount = 5) => BitmapToBitmapImage(ImageFromText(strText, fnt, clrFore, clrBack, blurAmount));

        private static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png); // 坑点：格式选Bmp时，不带透明度

                stream.Position = 0;
                var result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        private static Bitmap ImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount = 5)
        {
            Bitmap bmpOut = null;
            var sunNum = 255; //光晕的值
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var sz = g.MeasureString(strText, fnt);
                using (var bmp = new Bitmap((int)sz.Width, (int)sz.Height))
                using (var gBmp = Graphics.FromImage(bmp))
                using (var brBack = new SolidBrush(Color.FromArgb(sunNum, clrBack.R, clrBack.G, clrBack.B)))
                using (var brFore = new SolidBrush(clrFore))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gBmp.DrawString(strText, fnt, brBack, 0, 0);
                    bmpOut = new Bitmap(bmp.Width + blurAmount, bmp.Height + blurAmount);
                    using (var gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        //阴影光晕
                        for (var x = 0; x <= blurAmount; x++)
                        {
                            for (var y = 0; y <= blurAmount; y++)
                            {
                                gBmpOut.DrawImageUnscaled(bmp, x, y);
                            }
                        }

                        gBmpOut.DrawString(strText, fnt, brFore, blurAmount / 2, blurAmount / 2);
                    }
                }
            }

            return bmpOut;
        }
    }
}