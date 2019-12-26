using Reedoo.NET.XAML;
using RomanApp.Client.XAML.ViewModels.Login;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Login
{
    [ClientView(KEY, typeof(LoginViewModel))]
    public sealed partial class LoginView : Page
    {
        private const string KEY = "RomanApp.Offline.Gate.Login";

        public LoginView()
        {
            InitializeComponent();
        }
    }
}
