using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

namespace WpfDesignAndAnimationLab.AnimationDemos.OutlinedText
{
    public class FancyText
    {
        private static System.Windows.Media.Imaging.BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // 坑点：格式选Bmp时，不带透明度

                stream.Position = 0;
                System.Windows.Media.Imaging.BitmapImage result = new System.Windows.Media.Imaging.BitmapImage();
                result.BeginInit();
                result.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        private static Bitmap ImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount = 5)
        {
            Bitmap bmpOut = null;
            int sunNum = 255;  //光晕的值
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF sz = g.MeasureString(strText, fnt);
                using (Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height))
                using (Graphics gBmp = Graphics.FromImage(bmp))
                using (SolidBrush brBack = new SolidBrush(Color.FromArgb(sunNum, clrBack.R, clrBack.G, clrBack.B)))
                using (SolidBrush brFore = new SolidBrush(clrFore))
                {
                    gBmp.SmoothingMode = SmoothingMode.HighQuality;
                    gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gBmp.DrawString(strText, fnt, brBack, 0, 0);
                    bmpOut = new Bitmap(bmp.Width + blurAmount, bmp.Height + blurAmount);
                    using (Graphics gBmpOut = Graphics.FromImage(bmpOut))
                    {
                        gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
                        gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
                        gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        //阴影光晕
                        for (int x = 0; x <= blurAmount; x++)
                        {
                            for (int y = 0; y <= blurAmount; y++)
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

        /// <summary>
        /// 文本转图片
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="fnt"></param>
        /// <param name="clrFore"></param>
        /// <param name="clrBack"></param>
        /// <param name="blurAmount"></param>
        /// <returns></returns>
        public static System.Windows.Media.Imaging.BitmapImage BitmapImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount = 5)
        {

            return BitmapToBitmapImage(ImageFromText(strText, fnt, clrFore, clrBack, blurAmount));
        }

    }
}