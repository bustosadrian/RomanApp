using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Views.Sheet.Dialogs
{
    public sealed partial class AddEditItemDialog : ContentDialog
    {
        public AddEditItemDialog()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide(AddEditItemDialogResult.Delete);
        }

        private void btnCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide(AddEditItemDialogResult.Cancel);
        }

        private void btnSave_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide(AddEditItemDialogResult.Save);
        }

        private void Hide(AddEditItemDialogResult result)
        {
            Result = result;
            Hide();
        }

        #region Properties

        public AddEditItemDialogResult Result
        {
            get;
            private set;
        }

        #endregion
    }

    public enum AddEditItemDialogResult
    {
        Delete = 0,
        Cancel = 1,
        Save = 2,
    }
}
