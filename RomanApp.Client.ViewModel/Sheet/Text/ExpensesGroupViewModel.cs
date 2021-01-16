using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class ExpensesGroupViewModel : BaseViewModel
    {

        public ExpensesGroupViewModel(ExpensesGroupOutput message)
        {
            HasCreditors = message.HasCreditors;

            Remaining = message.Remaining;

            Debtors = new ObservableCollection<string>(message.Debtors);

            Expenses = new ObservableCollection<NameAmountViewModel>(
                message.Expenses.Select(x => new NameAmountViewModel(x)));
        }

        #region Properties

        private bool _hasCreditors;
        public bool HasCreditors
        {
            get
            {
                return _hasCreditors;
            }
            set
            {
                _hasCreditors = value;
                OnPropertyChanged(nameof(HasCreditors));
            }
        }

        private decimal _remaining;
        public decimal Remaining
        {
            get
            {
                return _remaining;
            }
            set
            {
                _remaining = value;
                OnPropertyChanged(nameof(Remaining));
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
