using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class ItemFormViewModel : BaseViewModel
    {
        public ItemFormViewModel()
        {
            IsGuest = true;
        }

        #region Commadns

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
