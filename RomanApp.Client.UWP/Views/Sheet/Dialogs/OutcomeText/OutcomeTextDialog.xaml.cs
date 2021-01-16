using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Views.Sheet.Dialogs.OutcomeText
{
    public sealed partial class OutcomeTextDialog : ContentDialog
    {
        public OutcomeTextDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            var heightString = await sender.InvokeScriptAsync("eval", new[] { "document.body.scrollHeight.toString()" });
            int height;
            if (int.TryParse(heightString, out height))
            {
                sender.Height = height;
            }
        }
    }
}
