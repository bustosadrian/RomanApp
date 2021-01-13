using RomanApp.Client.ViewModel;
using RomanApp.Messages;

namespace RomanApp.Client.ViewModel.Help
{
    public class RelatedTopicViewModel : BasicViewModel
    {
        public RelatedTopicViewModel(HelpTopic topic)
        {
            Topic = topic;
        }

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
                OnPropertyChanged(nameof(HelpTopic));
            }
        }

        #endregion
    }
}
