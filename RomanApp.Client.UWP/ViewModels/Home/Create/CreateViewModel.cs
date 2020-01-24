using Reedoo.NET.Messages;
using RomanApp.Messages.Home.Input;
using RomanApp.Messages.Home.Output;

namespace RomanApp.Client.UWP.ViewModels.Home.Create
{
    public class CreateViewModel : HomeViewModel
    {
        public CreateViewModel()
        {
            IsPublic = false;
            IsPrivate = true;
        }

        private void OnCreate()
        {
            CreateEventFormInput form = new CreateEventFormInput()
            {
                Name = EventName,
                EventAccess = IsPrivate ? EventAccess.Private : EventAccess.Public,
                Password = EventPassword,
            };
            Send(form);
        }

        #region Messages

        [Reader]
        public bool Read(CreateEventSetup message)
        {
            ShowAccessSection = message.IsAccessEnabled;
            return true;
        }

        #endregion

        #region Commands

        private DelegateCommand _createCommand;
        public DelegateCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(OnCreate);
                }
                return _createCommand;
            }
        }

        #endregion

        #region Properties

        private bool _showAccessSection;
        public bool ShowAccessSection
        {
            get
            {
                return _showAccessSection;
            }
            set
            {
                _showAccessSection = value;
                OnPropertyChanged("ShowAccessSection");
            }
        }

        private bool _isPublicSectionEnabled;
        public bool IsPublicSectionEnabled
        {
            get
            {
                return _isPublicSectionEnabled;
            }
            set
            {
                _isPublicSectionEnabled = value;
                OnPropertyChanged("IsPublicSectionEnabled");
            }
        }

        private string _eventName;
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                _eventName = value;
                OnPropertyChanged("EventName");
            }
        }

        private bool _isPrivate;
        public bool IsPrivate
        {
            get
            {
                return _isPrivate;
            }
            set
            {
                _isPrivate = value;
                OnPropertyChanged("IsPrivate");
            }
        }

        private bool _isPublic;
        public bool IsPublic
        {
            get
            {
                return _isPublic;
            }
            set
            {
                _isPublic = value;
                OnPropertyChanged("IsPublic");
                IsPublicSectionEnabled = _isPublic;
            }
        }

        private string _eventPassword;
        public string EventPassword
        {
            get
            {
                return _eventPassword;
            }
            set
            {
                _eventPassword = value;
                OnPropertyChanged("EventPassword");
            }
        }

        #endregion
    }
}
