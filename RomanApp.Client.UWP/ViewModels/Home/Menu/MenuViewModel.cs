using Reedoo.NET.Messages;
using RomanApp.Messages.Home.Input;
using RomanApp.Messages.Home.Output;

namespace RomanApp.Client.UWP.ViewModels.Home.Menu
{
    public class MenuViewModel : HomeViewModel
    {
        private void LoadBriifeng(MenuBriefingOutput briefing)
        {
            briefing.RemoteAccessEnabled = briefing.RemoteAccessEnabled;
            if (string.IsNullOrEmpty(briefing.CurrentEventName))
            {
                CurrentEventName = null;
                IsResumeEnabled = false;
            }
            else
            {
                CurrentEventName = briefing.CurrentEventName;
                IsResumeEnabled = true;
            }
        }

        private void GoToCreate()
        {
            Send(new CreateEventInput());
        }

        private void GoToHelp()
        {
            Send(new HelpInput());
        }

        private void GoToResumeEvent()
        {
            Send(new ResumeEventInput());
        }

        #region Commands

        private DelegateCommand _helpCommand;
        public DelegateCommand HelpCommand
        {
            get
            {
                if (_helpCommand == null)
                {
                    _helpCommand = new DelegateCommand(GoToHelp);
                }
                return _helpCommand;
            }
        }

        private DelegateCommand _createCommand;
        public DelegateCommand CreateEventCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(GoToCreate);
                }
                return _createCommand;
            }
        }

        private DelegateCommand _resumeEventCommand;
        public DelegateCommand ResumeEventCommand
        {
            get
            {
                if (_resumeEventCommand == null)
                {
                    _resumeEventCommand = new DelegateCommand(GoToResumeEvent);
                }
                return _resumeEventCommand;
            }
        }

        #endregion

        #region Messages

        [Reader]
        public bool Read(MenuBriefingOutput message)
        {
            LoadBriifeng(message);
            return true;
        }

        #endregion

        #region Properties

        private bool _isRemoteAccessEnabled;
        public bool IsRemoteAccessEnabled
        {
            get
            {
                return _isRemoteAccessEnabled;
            }
            set
            {
                _isRemoteAccessEnabled = value;
                OnPropertyChanged("IsRemoteAccessEnabled");
            }
        }

        private bool _isResumeEnabled;
        public bool IsResumeEnabled
        {
            get
            {
                return _isResumeEnabled;
            }
            set
            {
                _isResumeEnabled = value;
                OnPropertyChanged("IsResumeEnabled");
            }
        }

        private string _currentEventName;
        public string CurrentEventName
        {
            get
            {
                return _currentEventName;
            }
            set
            {
                _currentEventName = value;
                OnPropertyChanged("CurrentEventName");
            }
        }

        #endregion
    }
}
