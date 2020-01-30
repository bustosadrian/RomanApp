﻿using System;
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
            Send(new ChangeMyContributionInput());
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

        #region Messages

        [Reader]
        public bool Read(SheetBriefingOutput message)
        {
            EventName = message.EventName;
            Guests = new ObservableCollection<GuestViewModel>(
                message.Guests.Select(x => new GuestViewModel(this, x)));

            Expenses = new ObservableCollection<ExpenseViewModel>(
                message.Expenses.Select(x => new ExpenseViewModel(this, x)));

            IsSelfContributionEnabled = message.HasIdentity;

            return true;
        }

        [Reader]
        public bool Read(GuestOutput message)
        {
            Guests.Add(new GuestViewModel(this, message));
            return true;
        }

        [Reader]
        public bool Read(ExpenseOutput message)
        {
            Expenses.Add(new ExpenseViewModel(this, message));
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
        public bool Read(YourContributionOutput message)
        {
            MyContributionDialog dialog = new MyContributionDialog();
            MyContributionViewModel vm = new MyContributionViewModel(this)
            {
                Amount = message.Amount,
            };

            dialog.DataContext = vm;
            dialog.ShowAsync();

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
                    _createItemCommand = new DelegateCommand(OnCreateItem);
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

        #endregion
    }
}
