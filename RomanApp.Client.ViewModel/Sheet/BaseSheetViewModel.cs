using Reedoo.NET.Client.Messages;
using Reedoo.NET.Messages;
using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RomanApp.Client.XAML.ViewModels.Sheet
{
    public abstract class BaseSheetViewModel : BusViewModel
    {
        public BaseSheetViewModel()
        {
            Guests = new ObservableCollection<BaseItemRowViewModel>();
            Expenses = new ObservableCollection<BaseItemRowViewModel>();
            Outcome = new OutcomeViewModel(this);
        }

        protected abstract BaseItemRowViewModel NewItemRow();

        protected void OnGoToSettings()
        {
            Send(new GoToSettingsInput());
        }

        protected void Reset()
        {
            Send(new ResetSheetInput());
        }

        protected void AddItem(AddEditItemViewModel viewModel)
        {
            AddItemInput message = new AddItemInput()
            {
                Type = viewModel.ItemType,
                Name = viewModel.Name,
                Amount = viewModel.Amount,
            };
            Send(message);
        }

        private BaseItemRowViewModel ToItemViewModel(ItemOutput item)
        {
            BaseItemRowViewModel retval = null;

            retval = NewItemRow();
            retval.Map(item);

            return retval;
        }

        #region Commands

        public ICommand NewItemCommand
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

        #endregion

        #region Messages

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

        #endregion

        #region Properties

        private ObservableCollection<BaseItemRowViewModel> _guests;
        [Embedded]
        public ObservableCollection<BaseItemRowViewModel> Guests
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

        private ObservableCollection<BaseItemRowViewModel> _expenses;
        [Embedded]
        public ObservableCollection<BaseItemRowViewModel> Expenses
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

        #endregion

    }
}
