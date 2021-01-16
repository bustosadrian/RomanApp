using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class TotalGroupViewModel : BaseViewModel
    {
        public TotalGroupViewModel(TotalGroupOutput message)
        {
            Total = message.Total;
            
            TotalGuests = message.TotalGuests;
            Expenses = new ObservableCollection<NameAmountViewModel>(
                message.Expenses.Select(x => new NameAmountViewModel(x)));
            HasExpenses = Expenses.Any();
        }

        #region Properties

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

        private ObservableCollection<NameAmountViewModel> _expenses;
        public ObservableCollection<NameAmountViewModel> Expenses
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


        #endregion
    }
}
