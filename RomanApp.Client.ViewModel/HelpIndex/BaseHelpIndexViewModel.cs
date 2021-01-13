using Reedoo.NET.Messages;
using RomanApp.Messages.Input.HelpIndex;
using RomanApp.Messages.Output.HelpIndex;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.HelpIndex
{
    public class BaseHelpIndexViewModel : BusViewModel
    {
        public BaseHelpIndexViewModel()
        {
            Topics = new ObservableCollection<HelpTopicViewModel>();
        }

        #region Command Methods

        protected void OnSelectedTopic(HelpTopicViewModel helpTopicViewModel)
        {
            Send(new SelectTopicInput()
            {
                Topic = helpTopicViewModel.Topic,
            });
        }

        #endregion

        #region Commands

        public ICommand SelectedTopicCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Messages

        [Reader]
        public bool Read(HelpTopicOutput message)
        {
            Topics.Add(new HelpTopicViewModel(SelectedTopicCommand, message));
            return true;
        }

        [Reader]
        public bool Read(ClearTopicsOutput message)
        {
            Topics.Clear();
            return true;
        }

        private ObservableCollection<HelpTopicViewModel> _topics;
        public ObservableCollection<HelpTopicViewModel> Topics
        {
            get
            {
                return _topics;
            }
            set
            {
                _topics = value;
                OnPropertyChanged(nameof(Topics));
            }
        }

        #endregion
    }
}
