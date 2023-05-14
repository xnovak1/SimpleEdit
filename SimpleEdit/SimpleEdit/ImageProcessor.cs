using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleEdit
{
    internal class ImageProcessor
    {
        public static Task<Bitmap> Grayscale(Bitmap bitmap)
        {
            return Task.Run(() =>
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
            });
        }

        public static Task<Bitmap> InvertColors(Bitmap bitmap)
        {
            return Task.Run(() => {
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
            });
        }

        public static Bitmap FlipImage(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap);
            result.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return result;
        }

        // source: https://stackoverflow.com/questions/44827093/how-to-apply-blur-effect-on-a-bitmap-image-in-c
        public static unsafe Task<Bitmap> Blur(Bitmap bitmap, int blurSize)
        {
            return Task.Run(() =>
            {
                var result = new Bitmap(bitmap);
                var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                BitmapData blurredData = result.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, result.PixelFormat);

                int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(result.PixelFormat);

                byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

                for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
                {
                    for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                    {
                        int avgR = 0, avgG = 0, avgB = 0;
                        int blurPixelCount = 0;

                        for (int x = xx; (x < xx + blurSize && x < bitmap.Width); x++)
                        {
                            for (int y = yy; (y < yy + blurSize && y < bitmap.Height); y++)
                            {
                                byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                                avgB += data[0];
                                avgG += data[1];
                                avgR += data[2];

                                blurPixelCount++;
                            }
                        }

                        avgR /= blurPixelCount;
                        avgG /= blurPixelCount;
                        avgB /= blurPixelCount;

                        for (int x = xx; x < xx + blurSize && x < bitmap.Width && x < rectangle.Width; x++)
                        {
                            for (int y = yy; y < yy + blurSize && y < bitmap.Height && y < rectangle.Height; y++)
                            {
                                byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                                data[0] = (byte)avgB;
                                data[1] = (byte)avgG;
                                data[2] = (byte)avgR;
                            }
                        }
                    }
                }

                result.UnlockBits(blurredData);

                return result;
            });
        }

        public static Bitmap Nuke(Bitmap bitmap)
        {
            var result = new Bitmap(bitmap.Width, bitmap.Height);
            return result;
        }
    }
}
