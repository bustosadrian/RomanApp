using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Settings;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Settings
{
    [ClientView(KEY, typeof(SettingsViewModel))]
    public sealed partial class SettingsView : Page
    {
        private const string KEY = "RomanApp.Settings";

        public SettingsView()
        {
            this.InitializeComponent();
        }
    }
}
