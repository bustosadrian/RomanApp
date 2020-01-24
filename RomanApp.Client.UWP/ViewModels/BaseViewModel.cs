using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Output;
using Reedoo.NET.XAML;
using RomanApp.Messages.Input;
using System.ComponentModel;

namespace RomanApp.Client.UWP.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IViewModelBus
    {
        public virtual void Send(InputMessage message)
        {
            Bus.Send(message);
        }

        protected void LogOut()
        {
            Send(new LogOutMessage());
        }

        #region Bus

        public Bus Bus
        {
            get;
            set;
        }

        #endregion

        #region Messages

        [Reader]
        public bool Read(ValidationErrors message)
        {
            ValidationErrors = message;
            return true;
        }

        #endregion

        #region Commands

        private DelegateCommand _logOutCommand;
        public DelegateCommand LogOutCommand
        {
            get
            {
                if (_logOutCommand == null)
                {
                    _logOutCommand = new DelegateCommand(LogOut);
                }
                return _logOutCommand;
            }
        }

        #endregion

        #region Properties

        private ValidationErrors _validationErrors;
        public ValidationErrors ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
            set
            {
                _validationErrors = value;
                OnPropertyChanged("ValidationErrors");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
