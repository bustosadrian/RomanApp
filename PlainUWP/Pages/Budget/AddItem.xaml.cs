using PlainUWP.ViewModels.Budget;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlainUWP.Pages.Budget
{
    public sealed partial class AddItem : ContentDialog
    {
        public AddItem()
        {
            this.InitializeComponent();
            DataContext = new AddItemViewModel();
        }

        private void FocusLabel()
        {
            Label.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        #region Event

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            FocusLabel();
        }

        private void ContentDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            FocusLabel();
        }

        #endregion
    }
}
