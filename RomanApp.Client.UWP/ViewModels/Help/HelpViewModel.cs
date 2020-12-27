using RomanApp.Client.ViewModel.Help;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.ViewModels.Help
{
    public class HelpViewModel : BaseHelpViewModel
    {

        public HelpViewModel()
        {
            BackCommand = new XamlUICommand();
            ((XamlUICommand)BackCommand).ExecuteRequested += (s, e) => {
                OnBack();
            };
        }

    }
}
