using RomanApp.Messages.Output.Sheet.Outcome.Text;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class OutcomeTextViewModel : BaseViewModel
    {

        public OutcomeTextViewModel(OutcomeTextOutput message)
        {
            Total = new TotalGroupViewModel(message.Total);

            Share = new ShareGroupViewModel(message.Share);

            Debtors = new DebtorsGroupViewModel(message.Debtors);

            if(message.Collected != null)
            {
                Collected = new CollectedGroupViewModel(message.Collected);
            }

            if (message.Expenses != null)
            {
                Expenses = new ExpensesGroupViewModel(message.Expenses);
            }

            if(message.LeftOver != null)
            {
                LeftOver = new LeftOverTextViewModel(message.LeftOver);
            }

            if (message.Evens != null)
            {
                Evens = new EvensGroupViewModel(message.Evens);
            }

            UseWholeNumbers = message.UseWholeNumbers;
        }

        #region Properties
       
        private TotalGroupViewModel _total;
        public TotalGroupViewModel Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }


        private ShareGroupViewModel _share;
        public ShareGroupViewModel Share
        {
            get
            {
                return _share;
            }
            set
            {
                _share = value;
                OnPropertyChanged(nameof(Share));
            }
        }

        private DebtorsGroupViewModel _debtors;
        public DebtorsGroupViewModel Debtors
        {
            get
            {
                return _debtors;
            }
            set
            {
                _debtors = value;
                OnPropertyChanged(nameof(Debtors));
            }
        }

        private CollectedGroupViewModel _collected;
        public CollectedGroupViewModel Collected
        {
            get
            {
                return _collected;
            }
            set
            {
                _collected = value;
                OnPropertyChanged(nameof(Collected));
            }
        }

        private ExpensesGroupViewModel _expenses;
        public ExpensesGroupViewModel Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                OnPropertyChanged(nameof(Expenses));
            }
        }

        private LeftOverTextViewModel _leftOver;
        public LeftOverTextViewModel LeftOver
        {
            get
            {
                return _leftOver;
            }
            set
            {
                _leftOver = value;
                OnPropertyChanged(nameof(LeftOver));
            }
        }

        private EvensGroupViewModel _evens;
        public EvensGroupViewModel Evens
        {
            get
            {
                return _evens;
            }
            set
            {
                _evens = value;
                OnPropertyChanged(nameof(Evens));
            }
        }

        private bool _useWholeNumbers;
        public bool UseWholeNumbers
        {
            get
            {
                return _useWholeNumbers;
            }
            set
            {
                _useWholeNumbers = value;
                OnPropertyChanged(nameof(UseWholeNumbers));
            }
        }

        #endregion
    }
}
