using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Login;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Views.Login
{
    [ClientView(KEY, typeof(ShareViewModel))]
    public sealed partial class ShareView : Page
    {
        private const string KEY = "RomanApp.Offline.Gate.Share";

        public ShareView()
        {
            this.InitializeComponent();
        }
    }
}
