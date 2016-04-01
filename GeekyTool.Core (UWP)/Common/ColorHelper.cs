using System;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace GeekyTool.Core.Common
{
    public class ColorHelper
    {
        public static SolidColorBrush GetBrushColorFromHexa(string hexaColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    255,
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16)
                )
            );
        }

        public static Color GetColorFromHexa(string hexaColor)
        {
            return Color.FromArgb(
                255,
                Convert.ToByte(hexaColor.Substring(1, 2), 16),
                Convert.ToByte(hexaColor.Substring(3, 2), 16),
                Convert.ToByte(hexaColor.Substring(5, 2), 16)
                );
        }

        public static async Task<Color> GetDominantColor(StorageFile file)
        {
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                //Create a decoder for the image
                var decoder = await BitmapDecoder.CreateAsync(stream);

                //Create a transform to get a 1x1 image
                var myTransform = new BitmapTransform { ScaledHeight = 1, ScaledWidth = 1 };

                //Get the pixel provider
                var pixels = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Rgba8,
                    BitmapAlphaMode.Ignore,
                    myTransform,
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);

                //Get the bytes of the 1x1 scaled image
                var bytes = pixels.DetachPixelData();

                //read the color 
                return Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
            }
        }

        public static Color InvertColor(string value)
        {
            if (value != null)
            {
                var ColorToConvert = GetColorFromHexa(value);
                var invertedColor = Color.FromArgb(255, (byte)~ColorToConvert.R, (byte)~ColorToConvert.G, (byte)~ColorToConvert.B);
                return invertedColor;
            }
            else
            {
                return new Color();
            }
        }
    }
}
