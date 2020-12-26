using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Dialogs
{
    public sealed partial class YesNoDialog : ContentDialog
    {
        public YesNoDialog()
        {
            this.InitializeComponent();
        }

        public YesNoDialog(string title, string verbiage)
            : this()
        {
            Title = title;
            Verbiage = verbiage;
        }

        #region Properties

        public static readonly DependencyProperty VerbiageProperty =
            DependencyProperty.Register("Verbiage", typeof(string),
        typeof(YesNoDialog), new PropertyMetadata(null));
        public string Verbiage
        {
            get { return (string)GetValue(VerbiageProperty); }
            set { SetValue(VerbiageProperty, value); }
        }

        #endregion
    }
}
