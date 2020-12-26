using RomanApp.Client.ViewModel.Settings;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.ViewModels.Settings
{
    public class SettingsViewModel : BaseSettingsViewModel
    {
        public SettingsViewModel()
        {
            BackCommand = new XamlUICommand();
            ((XamlUICommand)BackCommand).ExecuteRequested += (s, e) => {
                OnBack();
            };

            SaveCommand = new XamlUICommand();
            ((XamlUICommand)SaveCommand).ExecuteRequested += (s, e) => {
                OnSave();
            };
        }
    }
}
