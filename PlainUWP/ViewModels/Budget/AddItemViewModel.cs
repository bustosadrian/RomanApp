namespace PlainUWP.ViewModels.Budget
{
    public class AddItemViewModel : BaseViewModel
    {
        public AddItemViewModel()
        {
            IsGuestChecked = true;
            IsExpenseChecked = false;
        }

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
