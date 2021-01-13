using RomanApp.Messages;
using RomanApp.Messages.Output.HelpIndex;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.HelpIndex
{
    public class HelpTopicViewModel : BaseViewModel
    {

        public HelpTopicViewModel(ICommand selectedTopicCommand,  HelpTopicOutput message)
        {
            SelectedTopicCommand = selectedTopicCommand;

            Topic = message.Topic;

            SubTopics = new ObservableCollection<HelpTopicViewModel>(
                message.SubTopics.Select(x => new HelpTopicViewModel(selectedTopicCommand, x)));
        }

        #region Commands

        public ICommand SelectedTopicCommand
        {
            get;
            private set;
        }

        #endregion

        #region Properties

        private HelpTopic _topic;
        public HelpTopic Topic
        {
            get
            {
                return _topic;
            }
            set
            {
                _topic = value;
                OnPropertyChanged(nameof(Topic));
            }
        }

        private ObservableCollection<HelpTopicViewModel>_subTopics;
        public ObservableCollection<HelpTopicViewModel> SubTopics
        {
            get
            {
                return _subTopics;
            }
            set
            {
                _subTopics = value;
                OnPropertyChanged(nameof(SubTopics));
            }
        }

        #endregion
    }
}
