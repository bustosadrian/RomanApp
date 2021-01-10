
using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.Mobile.ViewModels.Settings;
using RomanApp.Client.ViewModel;
using RomanApp.Commons;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.SETTINGS, typeof(SettingsViewModel))]
    public partial class SettingsView : NavigablePage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            ((BusViewModel)BindingContext).GoBack();

            return true;
        }

    }
}