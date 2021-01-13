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

        public BaseHelpViewModel()
        {
            RelatedTopics = new ObservableCollection<RelatedTopicViewModel>();
        }

        protected void OnGoToIndex()
        {
            Send(new GoToHelpIndexInput());
        }

        protected void OnSeeAlso(RelatedTopicViewModel relatedTopicViewModel)
        {
            Send(new SeeAlsoInput(){
                Topic = relatedTopicViewModel.Topic,
            });
        }

        #endregion

        #region Commands

        public ICommand GoToIndexCommand
        {
            get;
            protected set;
        }

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

            RelatedTopics.Clear();
            foreach(var o in message.RelatedTopics)
            {
                RelatedTopics.Add(new RelatedTopicViewModel(o));
            }

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
