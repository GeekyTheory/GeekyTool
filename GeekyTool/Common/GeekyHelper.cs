using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Xaml.Media;

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
    }
}
