using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Settings;
using RomanApp.Commons;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Settings
{
    [ClientView(StatesKeys.SETTINGS, typeof(SettingsViewModel))]
    public sealed partial class SettingsView : Page
    {
        public SettingsView()
        {
            this.InitializeComponent();
        }
    }
}
