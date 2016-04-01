using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace GeekyTool.Core.Common
{
    public class EncodeHelper
    {
        public static async Task<string> ToBase64(Image control)
        {
            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(control);
            return await ToBase64(bitmap);
        }

        public static async Task<string> ToBase64(WriteableBitmap bitmap)
        {
            var bytes = bitmap.PixelBuffer.ToArray();
            return await ToBase64(bytes, (uint)bitmap.PixelWidth,
                (uint)bitmap.PixelHeight);
        }

        public static async Task<string> ToBase64(StorageFile bitmap)
        {
            var stream = await bitmap
                .OpenAsync(Windows.Storage.FileAccessMode.Read);
            var decoder = await BitmapDecoder.CreateAsync(stream);
            var pixels = await decoder.GetPixelDataAsync();
            var bytes = pixels.DetachPixelData();
            return await ToBase64(bytes, (uint)decoder.PixelWidth,
                (uint)decoder.PixelHeight, decoder.DpiX, decoder.DpiY);
        }

        public static async Task<string> ToBase64(RenderTargetBitmap bitmap)
        {
            var bytes = (await bitmap.GetPixelsAsync()).ToArray();
            return await ToBase64(bytes, (uint)bitmap.PixelWidth,
                (uint)bitmap.PixelHeight);
        }

        public static async Task<string> ToBase64(BitmapImage bitmap)
        {
            var sources = bitmap as BitmapSource;
            var writeable = sources as WriteableBitmap;
            var bytes = writeable.PixelBuffer.ToArray();
            return await ToBase64(bytes, (uint)writeable.PixelWidth,
                (uint)writeable.PixelHeight);
        }

        public static async Task<string> ToBase64(byte[] image, uint height,
            uint width, double dpiX = 96, double dpiY = 96)
        {
            // encode image
            var encoded = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder
                .CreateAsync(BitmapEncoder.PngEncoderId, encoded);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Straight, height, width, dpiX, dpiY, image);
            await encoder.FlushAsync();
            encoded.Seek(0);

            // read bytes
            var bytes = new byte[encoded.Size];
            await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);

            // create base64
            return Convert.ToBase64String(bytes);
        }

        public static async Task<ImageSource> FromBase64(string base64)
        {
            // read stream
            var bytes = Convert.FromBase64String(base64);
            var image = bytes.AsBuffer().AsStream().AsRandomAccessStream();

            // decode image
            var decoder = await BitmapDecoder.CreateAsync(image);
            image.Seek(0);

            // create bitmap
            var output = new WriteableBitmap((int)decoder.PixelHeight,
                (int)decoder.PixelWidth);
            await output.SetSourceAsync(image);
            return output;
        }

        // ToDo refactor please if EncodeHelper is not the apropiate place
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
