using Reedoo.NET.Messages;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Help;
using RomanApp.Messages.Output.Help;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.Help
{
    public class BaseHelpViewModel : BusViewModel
    {
        #region Command Methods

        protected void OnSeeAlso(RelatedTopicViewModel relatedTopicViewModel)
        {
            Send(new SeeAlsoInput(){
                Topic = relatedTopicViewModel.Topic,
            });
        }

        #endregion

        #region Commands

        public ICommand SeeAlsoCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Messages

        [Reader]
        public bool Read(ShowTopicOutput message)
        {
            Topic = message.Topic;

            RelatedTopics = new ObservableCollection<RelatedTopicViewModel>(
                message.RelatedTopics.Select(x => new RelatedTopicViewModel(x)));

            return true;
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

        private ObservableCollection<RelatedTopicViewModel> _relatedTopics;
        public ObservableCollection<RelatedTopicViewModel> RelatedTopics
        {
            get
            {
                return _relatedTopics;
            }
            set
            {
                _relatedTopics = value;
                OnPropertyChanged(nameof(RelatedTopics));
            }
        }


        #endregion

    }
}
