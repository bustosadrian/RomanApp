using RomanApp.Client.ViewModel.Help;
using RomanApp.Messages;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.ViewModels.Help
{
    public class HelpViewModel : BaseHelpViewModel
    {

        public HelpViewModel()
        {
            BackCommand = new XamlUICommand();
            ((XamlUICommand)BackCommand).ExecuteRequested += (s, e) => {
                GoBack();
            };

            SeeAlsoCommand = new XamlUICommand();
            ((XamlUICommand)SeeAlsoCommand).ExecuteRequested += (s, e) => {
                OnSeeAlso((RelatedTopicViewModel)e.Parameter);
            };
        }


        #region Commands

        public XamlUICommand BackCommand
        {
            get;
            set;
        }

        private RelatedTopicViewModel _selectedRelatedTopic;
        public RelatedTopicViewModel SelectedRelatedTopic
        {
            get
            {
                return _selectedRelatedTopic;
            }
            set
            {
                var previous = _selectedRelatedTopic;
                _selectedRelatedTopic = value;
                OnPropertyChanged(nameof(SelectedRelatedTopic));
                if (_selectedRelatedTopic != null && previous != _selectedRelatedTopic)
                {
                    OnSeeAlso(_selectedRelatedTopic);
                }

            }
        }

        #endregion
    }
}
