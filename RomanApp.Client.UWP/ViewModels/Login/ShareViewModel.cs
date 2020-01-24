using RomanApp.Client.XAML;
using RomanApp.Client.XAML.ViewModels;
using RomanApp.Messages.Input;

namespace RomanApp.Client.UWP.ViewModels.Login
{
    public class ShareViewModel : BaseViewModel
    {
        private void Submit()
        {
            Send(new MyShareMessage()
            {
                Amount = Amount,
                Description = Description,
            });
        }

        #region Commands

        private DelegateCommand _subtmiCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if (_subtmiCommand == null)
                {
                    _subtmiCommand = new DelegateCommand(Submit);
                }
                return _subtmiCommand;
            }
        }

        #endregion

        #region Properties

        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        #endregion
    }
}
