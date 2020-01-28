using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class ItemFormViewModel : EmbeddedViewModel
    {
        public ItemFormViewModel(BaseViewModel parent) 
            : base(parent)
        {
            IsGuest = true;
        }


        private void OnAddItem()
        {
            if (IsGuest)
            {
                Send(new AddGuestInput() {
                    Label = Label,
                    Amount = Amount,
                });
            }
            else if(IsExpense)
            {
                Send(new AddExpenseInput()
                {
                    Label = Label,
                    Amount = Amount,
                });
            }
        }

        #region Commadns

        private DelegateCommand _addItemCommand;
        public DelegateCommand AddItemCommand
        {
            get
            {
                if(_addItemCommand == null)
                {
                    _addItemCommand = new DelegateCommand(OnAddItem);
                }

                return _addItemCommand;
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

        private bool _isGuest;
        public bool IsGuest
        {
            get
            {
                return _isGuest;
            }
            set
            {
                _isGuest = value;
                OnPropertyChanged("IsGuest");
            }
        }

        private bool _isExpense;
        public bool IsExpense
        {
            get
            {
                return _isExpense;
            }
            set
            {
                _isExpense = value;
                OnPropertyChanged("IsExpense");
            }
        }

        #endregion
    }
}
