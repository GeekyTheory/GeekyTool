using System;
using System.Text.RegularExpressions;

namespace GeekyTool.Core.Extensions
{
    public static class StringExtensions
    {
        public static string EncodeRFC3986(this string value)
        {
            // From Twitterizer http://www.twitterizer.net/
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var encoded = Uri.EscapeDataString(value);

            return Regex
                .Replace(encoded, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper())
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("$", "%24")
                .Replace("!", "%21")
                .Replace("*", "%2A")
                .Replace("'", "%27")
                .Replace("%7E", "~");
        }
    }
}
