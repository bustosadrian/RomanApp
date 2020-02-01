using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public abstract class ItemAmountViewModel : EmbeddedViewModel
    {
        public ItemAmountViewModel(BaseViewModel parent, ItemAmountDialogTitle title)
            : base(parent)
        {
            Title = title.ToString();
        }

        private void OnSubmit()
        {
            UpdateContributionInput message = CreateUpdateContributionInput();
            message.Amount = Amount;
            Send(message);
        }

        protected abstract UpdateContributionInput CreateUpdateContributionInput();

        #region Commands

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand(OnSubmit);
                }
                return _submitCommand;
            }
        }

        #endregion

        #region Properties

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
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

        #endregion
    }

    public abstract class ItemAmountDialogTitle
    {

    }

    public class SelfAmountDialogTitle : ItemAmountDialogTitle
    {
        public override string ToString()
        {
            return "How much did you cheap in?";
        }
    }

    public class OtherGuestAmountDialogTitle : ItemAmountDialogTitle
    {
        private string _guestName;

        public OtherGuestAmountDialogTitle(string guestName)
        {
            _guestName = guestName;
        }

        public override string ToString()
        {
            return string.Format("How much did {0} cheap in?", _guestName);
        }
    }

    public class ExpenseAmountDialogTitle : ItemAmountDialogTitle
    {
        private string _expenseLabel;

        public ExpenseAmountDialogTitle(string expenseLabel)
        {
            _expenseLabel = expenseLabel;
        }

        public override string ToString()
        {
            return string.Format("How much did {0} cost?", _expenseLabel);
        }
    }
}
