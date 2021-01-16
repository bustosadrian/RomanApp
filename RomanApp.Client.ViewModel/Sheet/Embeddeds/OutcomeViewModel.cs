using Reedoo.NET.Client.Messages;
using Reedoo.NET.Messages;
using RomanApp.Messages.Output.Sheet.Outcome;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Embeddeds
{
    public class OutcomeViewModel : EmbeddedViewModel
    {

        public OutcomeViewModel(BusViewModel parent)
            : base(parent)
        {

        }

        #region Messages

        [Reader]
        public bool Read(OutcomeResultOutput message)
        {
            IsAvailable = false;
            NoTotal = false;
            NotEnoughtGuests = false;
            NoDebtors = false;
            switch (message.Value)
            {
                case OutcomeResult.NotEnoughGuests:
                    NotEnoughtGuests = true;
                    break;
                case OutcomeResult.NoTotal:
                    NoTotal = true;
                    break;
                case OutcomeResult.NoDebtors:
                    NoDebtors = true;
                    break;
                case OutcomeResult.Ready:
                    IsAvailable = true;
                    break;
            }
            return true;
        }

        [Reader]
        public bool Read(OutcomeSummaryOutput message)
        {
            TotalGuests = message.TotalGuests;
            TotalExpenses = message.TotalExpenses;
            TotalDebtors = message.TotalDebtors;
            TotalCreditors = message.TotalCreditors;

            Total = message.Total;
            Share = message.Share;
            UseWholeNumbers = message.UseWholeNumbers;
            return true;
        }

        [Reader]
        public bool Read(OutcomeGuestsOutput message)
        {
            Debtors = new ObservableCollection<OutcomeItemViewModel>(message.Debtors.Select(x => new OutcomeItemViewModel(x)));
            Creditors = new ObservableCollection<OutcomeItemViewModel>(message.Creditors.Select(x => new OutcomeItemViewModel(x)));
            Evens = new ObservableCollection<OutcomeItemViewModel>(message.Evens.Select(x => new OutcomeItemViewModel(x)));
            Expenses = new ObservableCollection<OutcomeItemViewModel>(message.Expenses.Select(x => new OutcomeItemViewModel(x)));

            DebtorsCount = Debtors.Count();
            CreditorsCount = Creditors.Count();
            EvensCount = Evens.Count();
            ExpensesCount = Expenses.Count();

            IsShowDebtors = DebtorsCount > 0;
            IsShowCreditors = CreditorsCount > 0;
            IsShowEvens = EvensCount > 0;
            IsShowExpenses = ExpensesCount > 0;

            IsShowTotalDebtors = DebtorsCount > 1;
            IsShowTotalCreditors = CreditorsCount > 1;

            return true;
        }



        #endregion

        #region Properties

        private bool _isAvailable;
        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }

        private bool _notEnoughtGuests;
        public bool NotEnoughtGuests
        {
            get
            {
                return _notEnoughtGuests;
            }
            set
            {
                _notEnoughtGuests = value;
                OnPropertyChanged(nameof(NotEnoughtGuests));
            }
        }

        private bool _notTotal;
        public bool NoTotal
        {
            get
            {
                return _notTotal;
            }
            set
            {
                _notTotal = value;
                OnPropertyChanged(nameof(NoTotal));
            }
        }

        private bool _notDebtors;
        public bool NoDebtors
        {
            get
            {
                return _notDebtors;
            }
            set
            {
                _notDebtors = value;
                OnPropertyChanged(nameof(NoDebtors));
            }
        }

        private decimal _totalGuests;
        public decimal TotalGuests
        {
            get
            {
                return _totalGuests;
            }
            set
            {
                _totalGuests = value;
                OnPropertyChanged(nameof(TotalGuests));
            }
        }


        private decimal _totalExpesnes;
        public decimal TotalExpenses
        {
            get
            {
                return _totalExpesnes;
            }
            set
            {
                _totalExpesnes = value;
                OnPropertyChanged(nameof(TotalExpenses));
            }
        }


        private decimal _total;
        public decimal Total
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

        private decimal _share;
        public decimal Share
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

        private ObservableCollection<OutcomeItemViewModel> _debtors;
        public ObservableCollection<OutcomeItemViewModel> Debtors
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

        private ObservableCollection<OutcomeItemViewModel> _creditors;
        public ObservableCollection<OutcomeItemViewModel> Creditors
        {
            get
            {
                return _creditors;
            }
            set
            {
                _creditors = value;
                OnPropertyChanged(nameof(Creditors));
            }
        }

        private ObservableCollection<OutcomeItemViewModel> _evens;
        public ObservableCollection<OutcomeItemViewModel> Evens
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

        private ObservableCollection<OutcomeItemViewModel> _expenses;
        public ObservableCollection<OutcomeItemViewModel> Expenses
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

        private bool _isShowDebtors;
        public bool IsShowDebtors
        {
            get
            {
                return _isShowDebtors;
            }
            set
            {
                _isShowDebtors = value;
                OnPropertyChanged(nameof(IsShowDebtors));
            }
        }

        private bool _isShowCreditors;
        public bool IsShowCreditors
        {
            get
            {
                return _isShowCreditors;
            }
            set
            {
                _isShowCreditors = value;
                OnPropertyChanged(nameof(IsShowCreditors));
            }
        }

        private bool _isShowEvens;
        public bool IsShowEvens
        {
            get
            {
                return _isShowEvens;
            }
            set
            {
                _isShowEvens = value;
                OnPropertyChanged(nameof(IsShowEvens));
            }
        }

        private bool _isShowExpenses;
        public bool IsShowExpenses
        {
            get
            {
                return _isShowExpenses;
            }
            set
            {
                _isShowExpenses = value;
                OnPropertyChanged(nameof(IsShowExpenses));
            }
        }

        private bool _isShowTotalDebtors;
        public bool IsShowTotalDebtors
        {
            get
            {
                return _isShowTotalDebtors;
            }
            set
            {
                _isShowTotalDebtors = value;
                OnPropertyChanged(nameof(IsShowTotalDebtors));
            }
        }

        private bool _isShowTotalCreditors;
        public bool IsShowTotalCreditors
        {
            get
            {
                return _isShowTotalCreditors;
            }
            set
            {
                _isShowTotalCreditors = value;
                OnPropertyChanged(nameof(IsShowTotalCreditors));
            }
        }


        private int _debtorsCount;
        public int DebtorsCount
        {
            get
            {
                return _debtorsCount;
            }
            set
            {
                _debtorsCount = value;
                OnPropertyChanged(nameof(DebtorsCount));
            }
        }

        private int _creditorsCount;
        public int CreditorsCount
        {
            get
            {
                return _creditorsCount;
            }
            set
            {
                _creditorsCount = value;
                OnPropertyChanged(nameof(CreditorsCount));
            }
        }

        private int _evensCount;
        public int EvensCount
        {
            get
            {
                return _evensCount;
            }
            set
            {
                _evensCount = value;
                OnPropertyChanged(nameof(EvensCount));
            }
        }

        private int _expensesCount;
        public int ExpensesCount
        {
            get
            {
                return _expensesCount;
            }
            set
            {
                _expensesCount = value;
                OnPropertyChanged(nameof(ExpensesCount));
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

        private decimal _totalDebtors;
        public decimal TotalDebtors
        {
            get
            {
                return _totalDebtors;
            }
            set
            {
                _totalDebtors = value;
                OnPropertyChanged(nameof(TotalDebtors));
            }
        }

        private decimal _totalCreditors;
        public decimal TotalCreditors
        {
            get
            {
                return _totalCreditors;
            }
            set
            {
                _totalCreditors = value;
                OnPropertyChanged(nameof(TotalCreditors));
            }
        }

        #endregion
    }
}
