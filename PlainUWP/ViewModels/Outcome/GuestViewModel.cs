namespace PlainUWP.ViewModels.Outcome
{
    public class GuestViewModel : BaseViewModel
    {
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

        private decimal _debt;
        public decimal Debt
        {
            get
            {
                return _debt;
            }
            set
            {
                _debt = value;
                OnPropertyChanged("Debt");
                Status = _debt < 0 ? GuestStatus.DEBTOR : GuestStatus.CREDITOR;
            }
        }

        private GuestStatus _status;
        public GuestStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        #endregion
    }

    public enum GuestStatus
    {
        DEBTOR, CREDITOR
    }
}
