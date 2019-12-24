using RomanApp.Messages.Input;

namespace RomanApp.Client.XAML.ViewModels.CreateItem
{
    public class CreateItemViewModel : BaseViewModel
    {
        public CreateItemViewModel()
        {
            IsGuestChecked = true;
            IsExpenseChecked = false;
        }

        private void Submit()
        {
            if (IsExpenseChecked)
            {
                Send(new AddExpenseMessage()
                {
                    Name = Label,
                    Amount = Amount,
                });
            }
            else if (IsGuestChecked)
            {
                Send(new AddGuestMessage()
                {
                    Name = Label,
                    Amount = Amount,
                });
            }
        }

        private void Cancel()
        {
            Send(new CancelMessage());
        }

        #region Commands

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand(Submit);
                }
                return _submitCommand;
            }
        }

        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new DelegateCommand(Cancel);
                }
                return _cancelCommand;
            }
        }

        #endregion

        #region Properties

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

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

        private bool _isGuestChecked;
        public bool IsGuestChecked
        {
            get
            {
                return _isGuestChecked;
            }
            set
            {
                _isGuestChecked = value;
                OnPropertyChanged("IsGuestChecked");
            }
        }

        private bool _isExpenseChecked;
        public bool IsExpenseChecked
        {
            get
            {
                return _isExpenseChecked;
            }
            set
            {
                _isExpenseChecked = value;
                OnPropertyChanged("IsExpenseChecked");
            }
        }


        #endregion

    }
}
