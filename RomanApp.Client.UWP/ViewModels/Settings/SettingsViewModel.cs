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
                GoBack();
            };

            GetHelpCommand = new XamlUICommand();
            ((XamlUICommand)GetHelpCommand).ExecuteRequested += (s, e) => {
                OnGetHelp();
            };
        }

        #region Commands

        public XamlUICommand BackCommand
        {
            get;
            set;
        }

        #endregion
    }
}
