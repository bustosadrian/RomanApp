using Reedoo.NET.Messages;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output.Help;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.Help
{
    public class BaseHelpViewModel : BusViewModel
    {
        #region Commands

        #endregion

        #region Messages

        [Reader]
        public bool Read(ShowTopicOutput message)
        {
            Topic = message.Topic;

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

        #endregion

    }
}
