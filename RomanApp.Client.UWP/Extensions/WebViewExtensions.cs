using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Extensions
{
    public static class WebViewExtensions
    {

        public static readonly DependencyProperty HtmlSourceProperty =
           DependencyProperty.RegisterAttached("HtmlSource", typeof(string), typeof(WebViewExtensions), new PropertyMetadata("", OnHtmlSourceChanged));
        public static string GetHtmlSource(DependencyObject obj) { return (string)obj.GetValue(HtmlSourceProperty); }
        public static void SetHtmlSource(DependencyObject obj, string value) { obj.SetValue(HtmlSourceProperty, value); }
        private static void OnHtmlSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebView webView = d as WebView;
            if (webView != null)
            {
                string html = $"<html><body>{e.NewValue}</body></html>";
                webView.NavigateToString(html);

                
            }
        }
    }
    
}
