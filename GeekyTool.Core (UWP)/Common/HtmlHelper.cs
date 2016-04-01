using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeekyTool.Core.Common
{
    public class HtmlHelper
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
    }
}
