using RomanApp.Client.ViewModel.HelpIndex;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.HelpIndex
{
    public class HelpIndexViewModel : BaseHelpIndexViewModel
    {
        public HelpIndexViewModel()
        {
            SelectedTopicCommand = new Command<HelpTopicViewModel>(OnSelectedTopic);
        }
    }
}
