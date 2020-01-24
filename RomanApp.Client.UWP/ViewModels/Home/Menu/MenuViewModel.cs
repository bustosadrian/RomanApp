using RomanApp.Messages.Home.Input;

namespace RomanApp.Client.UWP.ViewModels.Home.Menu
{
    public class MenuViewModel : HomeViewModel
    {

        private void GoToCreate()
        {
            Send(new CreateEventInput());
        }

        private void GoToHelp()
        {
            Send(new HelpInput());
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

        #endregion
    }
}
