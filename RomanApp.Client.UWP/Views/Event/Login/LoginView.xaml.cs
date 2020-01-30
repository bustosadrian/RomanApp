using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Event.Login;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Views.Event.Login
{

    [ClientView(KEY, typeof(LoginViewModel))]
    public sealed partial class LoginView : Page
    {
        private const string KEY = "RomanApp.Event.Login";

        public LoginView()
        {
            this.InitializeComponent();
        }
    }
}
