using RomanApp.Client.ViewModel.Help;
using RomanApp.Messages;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Help
{
    public class HelpViewModel : BaseHelpViewModel
    {
        public HelpViewModel()
        {
            SeeAlsoCommand = new Command<RelatedTopicViewModel>(OnSeeAlso);
        }
    }
}
