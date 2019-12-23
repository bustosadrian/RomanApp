using PlainUWP.Entities;
using PlainUWP.Pages.Budget;
using PlainUWP.Pages.Outcome;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace PlainUWP.ViewModels.Budget
{
    public class BudgetViewModel : NavigationViewModel
    {
        public BudgetViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Expenses = new ObservableCollection<ExpenseViewModel>();
            Guests = new ObservableCollection<GuestViewModel>();
        }

        private async void NewItem()
        {
            AddItem dialog = new AddItem();
            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                AddItem((AddItemViewModel)dialog.DataContext);
            }
        }

        private void AddItem(AddItemViewModel model)
        {
            if (model.IsGuestChecked)
            {
                Guests.Add(new GuestViewModel()
                {
                    Label = model.Label,
                    Amount = model.Amount,
                });
                OnPropertyChanged("ShowGuests");
            }
            else if (model.IsExpenseChecked)
            {
                Expenses.Add(new ExpenseViewModel()
                {
                    Label = model.Label,
                    Amount = model.Amount,
                });
                OnPropertyChanged("ShowExpenses");
            }
        }

        private void Calculate()
        {
            Entities.Budget budget = new Entities.Budget();
            budget.Guests = Guests.Select(x => new Guest()
            {
                Label = x.Label,
                Amount = x.Amount,
            }).ToList();
            budget.Expenses = Expenses.Select(x => new Expense()
            {
                Label = x.Label,
                Amount = x.Amount,
            }).ToList();
            _navigationService.NavigateTo(typeof(OutcomePage), budget);
        }

        #region Commands

        private DelegateCommand _newItemCommand;
        public DelegateCommand NewItemCommand
        {
            get
            {
                if(_newItemCommand == null)
                {
                    _newItemCommand = new DelegateCommand(NewItem);
                }
                return _newItemCommand;
            }
        }

        private DelegateCommand _calculateCommand;
        public DelegateCommand CalculateCommand
        {
            get
            {
                if (_calculateCommand == null)
                {
                    _calculateCommand = new DelegateCommand(Calculate);
                }
                return _calculateCommand;
            }
        }

        #endregion

        #region Properties

        private ObservableCollection<ExpenseViewModel> _expenses;
        public ObservableCollection<ExpenseViewModel> Expenses
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

        private ObservableCollection<GuestViewModel> _guests;
        public ObservableCollection<GuestViewModel> Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                OnPropertyChanged("Guests");
            }
        }

        public bool ShowExpenses
        {
            get
            {
                return Expenses.Any();
            }
        }

        public bool ShowGuests
        {
            get
            {
                return Guests.Any();
            }
        }

        #endregion
    }
}
