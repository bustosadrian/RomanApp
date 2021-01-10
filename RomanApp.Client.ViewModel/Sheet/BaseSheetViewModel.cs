using Reedoo.NET.Client.Messages;
using Reedoo.NET.Messages;
using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RomanApp.Client.XAML.ViewModels.Sheet
{
    public abstract class BaseSheetViewModel : BusViewModel
    {
        public BaseSheetViewModel()
        {
            Guests = new ObservableCollection<ItemRowViewModel>();
            Expenses = new ObservableCollection<ItemRowViewModel>();
            Outcome = new OutcomeViewModel(this);
        }


        protected abstract void OnNewItem(ItemType itemType);

        protected void Reset()
        {
            Send(new ResetSheetInput());
        }

        protected void SaveItem(AddEditItemViewModel viewModel)
        {
            AddItemInput message = null;
            if (viewModel.IsEditing)
            {
                switch (viewModel.ItemType)
                {
                    case ItemType.Guest:
                        message = new EditGuestInput();
                        break;
                    case ItemType.Expense:
                        message = new EditExpenseInput();
                        break;
                }
                ((EditItemInput)message).ItemId = viewModel.Id;
            }
            else
            {
                switch (viewModel.ItemType)
                {
                    case ItemType.Guest:
                        message = new AddGuestInput();
                        break;
                    case ItemType.Expense:
                        message = new AddExpenseInput();
                        break;
                }
            }
            message.Name = viewModel.Name;
            message.Amount = viewModel.Amount;

            Send(message);
        }

        protected void Delete(AddEditItemViewModel viewModel)
        {
            Send(new RemoveItemInput()
            {
                ItemId = viewModel.Id,
                Type = viewModel.ItemType,
            });
        }

        private ItemRowViewModel ToItemViewModel(ItemOutput item)
        {
            ItemRowViewModel retval = null;

            retval = new ItemRowViewModel();
            retval.Map(item);

            return retval;
        }

        #region Command Methods

        protected void OnGoToSettings()
        {
            try
            {
                Send(new GoToSettingsInput());
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }
        protected void OnGoToHelp()
        {
            try
            {
                Send(new GoToHelpInput());
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        protected void OnNewGuest()
        {
            try
            {
                OnNewItem(ItemType.Guest);
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }
        protected void OnNewExpense()
        {
            try
            {
                OnNewItem(ItemType.Expense);
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        #endregion

        #region Commands

        public ICommand NewGuestCommand
        {
            get;
            protected set;
        }

        public ICommand NewExpenseCommand
        {
            get;
            protected set;
        }

        public ICommand GoToSettingsCommand
        {
            get;
            protected set;
        }

        public ICommand ResetCommand
        {
            get;
            protected set;
        }

        public ICommand GoToHelpCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Messages
        

        [Reader]
        public bool Read(ItemsCountOutput message)
        {
            GuestsCount = message.GuestsCounts;
            ExpensesCount = message.ExpensesCount;
            return true;
        }

        [Reader]
        public bool Read(ItemsAmountOutput message)
        {
            GuestsAmount = message.GuestsAmount;
            ExpensesAmount = message.ExpensesAmount;
            return true;
        }

        [Reader]
        public bool Read(ClearGuestsOutput message)
        {
            Guests.Clear();
            return true;
        }

        [Reader]
        public bool Read(ClearExpensesOutput message)
        {
            Expenses.Clear();
            return true;
        }

        [Reader]
        public bool Read(ItemOutput message)
        {
            var itemRow = ToItemViewModel(message);
            switch (itemRow.Type)
            {
                case ItemType.Guest:
                    Guests.Add(itemRow);
                    break;
                case ItemType.Expense:
                    Expenses.Add(itemRow);
                    break;
            }

            return true;
        }

        [Reader]
        public bool Read(RemoveItemOutput message)
        {
            switch (message.Type)
            {
                case ItemType.Guest:
                    var guest = Guests.SingleOrDefault(x => x.Id == message.Id);
                    if(guest != null)
                    {
                        Guests.Remove(guest);
                    }
                    break;
                case ItemType.Expense:
                    var exepense = Expenses.SingleOrDefault(x => x.Id == message.Id);
                    if (exepense != null)
                    {
                        Expenses.Remove(exepense);
                    }
                    break;
            }

            return true;
        }

        [Reader]
        public bool Read(EnableResetOutput message)
        {
            IsResetEnabled = message.ResetEnabled;
            ChangeCanExecute(ResetCommand);
            return true;
        }

        #endregion

        #region Properties

        private int _guestsCount;
        public int GuestsCount
        {
            get
            {
                return _guestsCount;
            }
            set
            {
                _guestsCount = value;
                OnPropertyChanged(nameof(GuestsCount));
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

        private decimal _guestsAmount;
        public decimal GuestsAmount
        {
            get
            {
                return _guestsAmount;
            }
            set
            {
                _guestsAmount = value;
                OnPropertyChanged(nameof(GuestsAmount));
            }
        }

        private decimal _expensesAmount;
        public decimal ExpensesAmount
        {
            get
            {
                return _expensesAmount;
            }
            set
            {
                _expensesAmount = value;
                OnPropertyChanged(nameof(ExpensesAmount));
            }
        }

        private ObservableCollection<ItemRowViewModel> _guests;
        [Embedded]
        public ObservableCollection<ItemRowViewModel> Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                OnPropertyChanged(nameof(Guests));
            }
        }

        private ObservableCollection<ItemRowViewModel> _expenses;
        [Embedded]
        public ObservableCollection<ItemRowViewModel> Expenses
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

        private OutcomeViewModel _outcome;
        [Embedded]
        public OutcomeViewModel Outcome
        {
            get
            {
                return _outcome;
            }
            set
            {
                _outcome = value;
                OnPropertyChanged(nameof(Outcome));
            }
        }

        private bool _isResetEnabled;
        public bool IsResetEnabled
        {
            get
            {
                return _isResetEnabled;
            }
            set
            {
                _isResetEnabled = value;
                OnPropertyChanged(nameof(IsResetEnabled));
            }
        }

        #endregion

    }
}
