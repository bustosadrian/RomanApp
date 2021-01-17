using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class CollectedGroupViewModel : BaseViewModel
    {
        public CollectedGroupViewModel(CollectedGroupOutput message)
        {
            TotalCopllected = message.TotalCollected;

            Debtors = new ObservableCollection<string>(message.Debtors);

            Creditors = new ObservableCollection<NameAmountViewModel>(
                message.Creditors.Select(x => new NameAmountViewModel(x)));

            HasExpenses = message.HasExpenses;

            if(Debtors.Count() == 1)
            {
                IsSingleDebtor = true;
                SingleDebtor = Debtors.Single();
            }
            
            if(Creditors.Count() == 1)
            {
                IsSingleCreditor = true;
                SingleCreditor = Creditors.Single();
            }
        }


        #region Properties

        private decimal _totalCollected;
        public decimal TotalCopllected
        {
            get
            {
                return _totalCollected;
            }
            set
            {
                _totalCollected = value;
                OnPropertyChanged(nameof(TotalCopllected));
            }
        }


        private ObservableCollection<string> _debtors;
        public ObservableCollection<string> Debtors
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

        private ObservableCollection<NameAmountViewModel> _creditors;
        public ObservableCollection<NameAmountViewModel> Creditors
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

        private bool _isSingleDebtor;
        public bool IsSingleDebtor
        {
            get
            {
                return _isSingleDebtor;
            }
            set
            {
                _isSingleDebtor = value;
                OnPropertyChanged(nameof(IsSingleDebtor));
            }
        }

        private bool _isSingleCreditor;
        public bool IsSingleCreditor
        {
            get
            {
                return _isSingleCreditor;
            }
            set
            {
                _isSingleCreditor = value;
                OnPropertyChanged(nameof(IsSingleCreditor));
            }
        }

        private string _singleDebtor;
        public string SingleDebtor
        {
            get
            {
                return _singleDebtor;
            }
            set
            {
                _singleDebtor = value;
                OnPropertyChanged(nameof(SingleDebtor));
            }
        }

        private NameAmountViewModel _singleCreditor;
        public NameAmountViewModel SingleCreditor
        {
            get
            {
                return _singleCreditor;
            }
            set
            {
                _singleCreditor = value;
                OnPropertyChanged(nameof(SingleCreditor));
            }
        }

        private bool _hasExpenses;
        public bool HasExpenses
        {
            get
            {
                return _hasExpenses;
            }
            set
            {
                _hasExpenses = value;
                OnPropertyChanged(nameof(HasExpenses));
            }
        }

        #endregion
    }
}
