using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;
using System.Collections.ObjectModel;

namespace RomanApp.Client.XAML.ViewModels.Budget
{
    public class BudgetViewModel : BaseViewModel
    {
        public BudgetViewModel()
        {
            Clear();
        }

        private void Clear()
        {
            Guests = new ObservableCollection<GuestViewModel>();

            Expenses = new ObservableCollection<ExpenseViewModel>();
        }

        private void NewItem()
        {
            Send(new NewItemMessage());
        }

        private void Reset()
        {
            Send(new ResetMessage());
        }

        private void Calculate()
        {
            Send(new CalculateMessage());
        }

        #region Messages

        [Reader]
        public bool Read(ExpenseMessage message)
        {
            Expenses.Add(new ExpenseViewModel()
            {
                Label = message.Label,
                Amount = message.Amount,
            });
            OnPropertyChanged("Expenses");
            return true;
        }

        [Reader]
        public bool Read(GuestMessage message)
        {
            Guests.Add(new GuestViewModel()
            {
                Label = message.Label,
                Amount = message.Amount,
            });
            OnPropertyChanged("Guests");
            return true;
        }

        [Reader]
        public bool Read(ClearMessage message)
        {
            Clear();
            return true;
        }

        #endregion

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

        private DelegateCommand _resetCommand;
        public DelegateCommand  ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new DelegateCommand(Reset);
                }
                return _resetCommand;
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
                OnPropertyChanged("ShowExpenses");
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
                OnPropertyChanged("ShowGuests");
            }
        }

        #endregion
    }
}
