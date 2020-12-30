using RomanApp.Client.ViewModel.Help;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Help
{
    public class HelpViewModel : BaseHelpViewModel
    {

        public HelpViewModel()
        {
            BackCommand = new Command(OnBack);
        }

    }
}
