using PlainUWP.Pages.Budget;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlainUWP.ViewModels.Outcome
{
    public class OutcomeViewModel : NavigationViewModel
    {
        private Entities.Budget _budget;

        public OutcomeViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }

        public void Load(Entities.Budget budget)
        {
            Creditors = new ObservableCollection<GuestViewModel>();
            Debtors = new ObservableCollection<GuestViewModel>();

            _budget = budget;

            decimal total = 0;
            decimal share = 0;
            decimal expensesTotal = 0;
            int guestsCount = 0;

            List<ExpenseViewModel> expenses = new List<ExpenseViewModel>();
            foreach (var o in _budget.Expenses)
            {
                ExpenseViewModel expense = new ExpenseViewModel()
                {
                    Description = o.Label,
                    Amount = o.Amount,
                };
                expenses.Add(expense);
                expensesTotal += expense.Amount;
            }

            total = expensesTotal;

            List<GuestViewModel> guests = new List<GuestViewModel>();
            foreach(var o in _budget.Guests)
            {
                GuestViewModel guest = new GuestViewModel()
                {
                    Name = o.Label,
                    Amount = o.Amount,
                };
                guests.Add(guest);
                total += guest.Amount;
                guestsCount++;
            }

            share = total / guestsCount;

            foreach(var o in guests)
            {
                o.Debt = o.Amount - share;
            }

            foreach(var o in guests)
            {
                switch (o.Status)
                {
                    case GuestStatus.CREDITOR:
                        Creditors.Add(o);
                        break;
                    case GuestStatus.DEBTOR:
                        Debtors.Add(o);
                        break;
                }
            }

            Total = total;
            Share = share;
        }

        private void Back()
        {
            _navigationService.NavigateTo(typeof(BudgetPage), _budget);
        }

        #region Commands

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new DelegateCommand(Back);
                }
                return _backCommand;
            }
        }

        #endregion

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
                OnPropertyChanged("Total");
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
                OnPropertyChanged("Share");
            }
        }

        private ObservableCollection<GuestViewModel> _debtors;
        public ObservableCollection<GuestViewModel> Debtors
        {
            get
            {
                return _debtors;
            }
            set
            {
                _debtors = value;
                OnPropertyChanged("Debtors");
            }
        }

        private ObservableCollection<GuestViewModel> _creditors;
        public ObservableCollection<GuestViewModel> Creditors
        {
            get
            {
                return _creditors;
            }
            set
            {
                _creditors = value;
                OnPropertyChanged("Creditors");
            }
        }

        #endregion
    }
}
