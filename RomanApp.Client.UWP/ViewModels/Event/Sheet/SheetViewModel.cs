using System;
using Reedoo.NET.Messages;
using Reedoo.NET.Utils.Reflect;
using RomanApp.Client.UWP.Views.Event.Sheet.Controls;
using RomanApp.Messages.Event.Output.Sheet;
using System.Collections.ObjectModel;
using System.Linq;
using RomanApp.Messages.Event.Input.Sheet;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class SheetViewModel : EventViewModel
    {
        private bool _isAdmin;

        public SheetViewModel()
        {
            ItemFormViewModel = new ItemFormViewModel();
            OutcomeViewModel = new OutcomeViewModel(this);
        }

        private async void OnCreateItem()
        {
            AddItemDialog dialog = new AddItemDialog();
            ItemFormViewModel vm = new ItemFormViewModel();
            dialog.DataContext = vm;
            ContentDialogResult result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                AddItem(vm);
            }
        }

        private void OnAddItem()
        {
            AddItem(ItemFormViewModel);
        }

        private void OnChangeMyContribution()
        {
            Send(new ChangeSelfContributionInput());
        }

        private void AddItem(ItemFormViewModel vm)
        {
            if (vm.IsGuest)
            {
                Send(new AddGuestInput()
                {
                    Label = vm.Label,
                    Amount = vm.Amount,
                });
            }
            else if (vm.IsExpense)
            {
                Send(new AddExpenseInput()
                {
                    Label = vm.Label,
                    Amount = vm.Amount,
                });
            }
        }

        private void ShowItemAmountDialog(ContributionOutput message,
            ItemAmountViewModel vm)
        {
            ItemAmountDialog dialog = new ItemAmountDialog();
            vm.Amount = message.Amount;

            dialog.DataContext = vm;
            dialog.ShowAsync();
        }


        #region Messages

        [Reader]
        public bool Read(SheetBriefingOutput message)
        {
            _isAdmin = message.IsAdmin;
            EventName = message.EventName;
            CanAddItems = _isAdmin;

            Guests = new ObservableCollection<GuestViewModel>(
                message.Guests
                    .OrderByDescending(x => x.IsSelf)
                    .Select(x => new GuestViewModel(this, x, _isAdmin)));

            Expenses = new ObservableCollection<ExpenseViewModel>(
                message.Expenses.Select(x => new ExpenseViewModel(this, x, _isAdmin)));

            IsSelfContributionEnabled = message.HasIdentity;

            

            return true;
        }

        [Reader]
        public bool Read(GuestOutput message)
        {
            Guests.Add(new GuestViewModel(this, message, _isAdmin));
            return true;
        }

        [Reader]
        public bool Read(ExpenseOutput message)
        {
            Expenses.Add(new ExpenseViewModel(this, message, _isAdmin));
            return true;
        }

        [Reader]
        public bool Read(RemoveGuestOutput message)
        {
            GuestViewModel o = Guests.SingleOrDefault(x => x.Id == message.ItemId);
            if(o != null)
            {
                Guests.Remove(o);
            }

            return true;
        }

        [Reader]
        public bool Read(RemoveExpenseOutput message)
        {
            ExpenseViewModel o = Expenses.SingleOrDefault(x => x.Id == message.ItemId);
            if (o != null)
            {
                Expenses.Remove(o);
            }

            return true;
        }

        [Reader]
        public bool Read(SelfContributionOutput message)
        {
            ShowItemAmountDialog(message, new SelfContributionViewModel(this));

            return true;
        }

        [Reader]
        public bool Read(OthersContributionOutput message)
        {
            ItemAmountViewModel vm = null;
            if (message.IsSelf)
            {
                vm = new SelfContributionViewModel(this);
            }
            else
            {
                vm = new OthersContributionViewModel(this, message.GuestName);
            }
            ShowItemAmountDialog(message, vm);

            return true;
        }

        [Reader]
        public bool Read(ExpenseAmountOutput message)
        {
            ItemAmountViewModel vm = null;
            vm = new ExpenseAmountViewModel(this, message.ExpenseLabel);
            ShowItemAmountDialog(message, vm);

            return true;
        }

        #endregion

        #region Commands

        private DelegateCommand _createItemCommand;
        public DelegateCommand CreateItemCommand
        {
            get
            {
                if(_createItemCommand == null)
                {
                    _createItemCommand = new DelegateCommand(OnCreateItem, () => CanAddItems);
                }
                return _createItemCommand;
            }
        }

        private DelegateCommand _addItemCommand;
        public DelegateCommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                {
                    _addItemCommand = new DelegateCommand(OnAddItem);
                }

                return _addItemCommand;
            }
        }

        private DelegateCommand _changeMyContributtionCommand;
        public DelegateCommand ChangeMyContributtionCommand
        {
            get
            {
                if (_changeMyContributtionCommand == null)
                {
                    _changeMyContributtionCommand =
                        new DelegateCommand(OnChangeMyContribution);
                }

                return _changeMyContributtionCommand;
            }
        }

        #endregion

        #region Properties

        private string _eventName;
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                _eventName = value;
                OnPropertyChanged("EventName");
            }
        }

        private ObservableCollection<ExpenseViewModel> _expenses;
        [Embedded]
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
        [Embedded]
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

        private ItemFormViewModel _itemFormViewModel;
        public ItemFormViewModel ItemFormViewModel
        {
            get
            {
                return _itemFormViewModel;
            }
            set
            {
                _itemFormViewModel = value;
                OnPropertyChanged("ItemFormViewModel");
            }
        }

        private OutcomeViewModel _outcomeViewModel;
        [Embedded]
        public OutcomeViewModel OutcomeViewModel
        {
            get
            {
                return _outcomeViewModel;
            }
            set
            {
                _outcomeViewModel = value;
                OnPropertyChanged("OutcomeViewModel");
            }
        }

        private bool _isSelfContributionEnabled;
        public bool IsSelfContributionEnabled
        {
            get
            {
                return _isSelfContributionEnabled;
            }
            set
            {
                _isSelfContributionEnabled = value;
                OnPropertyChanged("IsSelfContributionEnabled");
            }
        }

        private bool _canAddItems;
        public bool CanAddItems
        {
            get
            {
                return _canAddItems;
            }
            set
            {
                _canAddItems = value;
                OnPropertyChanged("CanAddItems");
                CreateItemCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion
    }
}
