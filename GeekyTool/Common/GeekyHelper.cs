using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace GeekyTool
{
    public class GeekyHelper
    {
        public static string ExtractFirstImageFromHtml(string content)
        {
            string matchString = Regex.Match(content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return matchString;
        }

        public static List<string> ExtractAllImagesFromHtml(string content)
        {
            List<string> images = new List<string>();
            
            MatchCollection matches = Regex.Matches(content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);

            for (int i = 0, l = matches.Count; i < l; i++)
            {
                images.Add(matches[i].Value);
            }

            return images;
        }

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

        public static bool ValidFeedUri(string feedUri)
        {
            if (string.IsNullOrEmpty(feedUri))
                return false;

            Uri uri;
            if (!Uri.TryCreate(feedUri.Trim(), UriKind.Absolute, out uri))
                return false;
            else
                return true;
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

        public static async Task<byte[]> GetStreamToBytesAsync(IRandomAccessStream fileStream)
        {
            using (DataReader reader = new DataReader(fileStream.GetInputStreamAt(0)))
            {
                await reader.LoadAsync((uint)fileStream.Size);
                byte[] pixeByte = new byte[fileStream.Size];
                reader.ReadBytes(pixeByte);
                return pixeByte;
            }
        }

        public static async Task<byte[]> ImageToByteArrayAsync(StorageFile file)
        {
            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                return await GetStreamToBytesAsync(stream);
            }
        }

        public static async Task<BitmapImage> ConvertByteArrayToBitmapImage(byte[] byteValue)
        {
            var img = new BitmapImage();

            var ras = new InMemoryRandomAccessStream();
            await ras.WriteAsync(byteValue.AsBuffer());
            await ras.FlushAsync();
            ras.Seek(0);
            img.SetSource(ras);

            return img;
        }

        
    }
}
