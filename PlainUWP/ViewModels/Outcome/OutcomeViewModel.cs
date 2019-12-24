using PlainUWP.Pages.Budget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

            Creditors = new ObservableCollection<GuestViewModel>(
                guests.Where(x => x.Status == GuestStatus.CREDITOR).ToList());
            Debtors = new ObservableCollection<GuestViewModel>(
                guests.Where(x => x.Status == GuestStatus.DEBTOR).ToList());

            Total = total;
            Share = share;
            Expenses = expensesTotal;
        }

        private void Restart()
        {
            _navigationService.NavigateTo(typeof(BudgetPage));
        }


        private void Back()
        {
            _navigationService.NavigateTo(typeof(BudgetPage), _budget);
        }

        #region Commands

        private DelegateCommand _restartCommand;
        public DelegateCommand RestartCommand
        {
            get
            {
                if (_restartCommand == null)
                {
                    _restartCommand = new DelegateCommand(Restart);
                }
                return _restartCommand;
            }
        }

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

        private decimal _expenses;
        public decimal Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                OnPropertyChanged("Expenses");
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
