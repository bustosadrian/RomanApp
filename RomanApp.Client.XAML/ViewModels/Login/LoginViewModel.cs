using RomanApp.Messages.Input;

namespace RomanApp.Client.XAML.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private void Submit()
        {
            Send(new LoginMessage()
            {
                Name = Name,
            });
        }

        #region Commands

        private DelegateCommand _subtmiCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if(_subtmiCommand == null)
                {
                    _subtmiCommand = new DelegateCommand(Submit);
                }
                return _subtmiCommand;
            }
        }

        #endregion

        #region Properties

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        #endregion
    }
}
