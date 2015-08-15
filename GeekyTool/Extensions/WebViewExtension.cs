using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GeekyTool.Extensions
{
    public class WebViewExtension
    {
        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.Register(
            "Html", typeof (string), typeof (WebViewExtension), new PropertyMetadata(0, new PropertyChangedCallback(OnHtmlChanged)));

        private static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebView wv = d as WebView;
            wv?.NavigateToString((string)e.NewValue);
        }
    }
}
