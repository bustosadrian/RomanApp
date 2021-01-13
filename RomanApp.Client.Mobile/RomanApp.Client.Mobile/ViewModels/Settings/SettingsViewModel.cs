using RomanApp.Client.ViewModel.Settings;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Settings
{
    public class SettingsViewModel : BaseSettingsViewModel
    {
        public SettingsViewModel()
        {
            GetHelpCommand = new Command(OnGetHelp);
        }
    }
}
