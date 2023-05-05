using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEdit
{
    internal class ImageProcessor
    {
        public static Bitmap Grayscale(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    // these magic numbers are standard for grayscale
                    byte gray = (byte)(.299 * color.R + .587 * color.G + .114 * color.B);

                    result.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            return result;
        }

        public static Bitmap InvertColors(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    result.SetPixel(i, j, Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B));
                }
            }

            return result;
        }

        public static Bitmap FlipImage(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap);
            result.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return result;
        }

        public static Bitmap Blur(Bitmap bitmap, int blurSize)
        {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            return result;
        }

        public static Bitmap Nuke(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            return result;
        }
    }
}
