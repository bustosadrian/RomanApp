
using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.ViewModels.Settings;
using RomanApp.Commons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.SETTINGS, typeof(SettingsViewModel))]
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }
    }
}