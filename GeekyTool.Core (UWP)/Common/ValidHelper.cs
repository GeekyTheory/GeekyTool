using System;

namespace GeekyTool.Core.Common
{
    public class ValidHelper
    {
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
