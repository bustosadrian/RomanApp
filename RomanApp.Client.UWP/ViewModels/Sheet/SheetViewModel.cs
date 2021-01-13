using Reedoo.NET.Client.Messages;
using RomanApp.Client.UWP.Dialogs;
using RomanApp.Client.UWP.ViewModels.Components;
using RomanApp.Client.UWP.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.ViewModels.Sheet
{
    public class SheetViewModel : BaseSheetViewModel
    {
        public SheetViewModel()
            : base ()
        {
            GoToSettingsCommand = new XamlUICommand();
            ((XamlUICommand)GoToSettingsCommand).ExecuteRequested += (s, e) => {
                OnGoToSettings();
            };

            GetHelpCommand = new XamlUICommand();
            ((XamlUICommand)GetHelpCommand).ExecuteRequested += (s, e) => {
                OnGetHelp();
            };

            NewGuestCommand = new XamlUICommand();
            ((XamlUICommand)NewGuestCommand).ExecuteRequested += (s, e) => { 
                OnNewGuest(); 
            };

            NewExpenseCommand = new XamlUICommand();
            ((XamlUICommand)NewExpenseCommand).ExecuteRequested += (s, e) => {
                OnNewExpense();
            };

            ResetCommand = new XamlUICommand();
            ((XamlUICommand)ResetCommand).ExecuteRequested += (s, e) => {
                OnReset();
            };

            EditItemCommand = new XamlUICommand();
            ((XamlUICommand)EditItemCommand).ExecuteRequested += (s, e) => {
                OnEditItem((ItemRowViewModel)e.Parameter);
            };

            Validations = new ValidationsViewModel(this);
        }

        protected override async void OnNewItem(ItemType itemType)
        {
            AddEditItemViewModel vm = new AddEditItemViewModel(itemType, false);
            AddEditItemDialog dialog = new AddEditItemDialog()
            {
                DataContext = vm,
            };
            
            await dialog.ShowAsync();
            switch (dialog.Result)
            {
                case AddEditItemDialogResult.Save:
                    SaveItem(vm);
                    break;
                default:
                    break;
            }
        }

        protected async void OnEditItem(ItemRowViewModel item)
        {
            AddEditItemViewModel vm = new AddEditItemViewModel(item.Id, item.Type, true)
            {
                Name = item.Name,
                Amount = item.Amount,
            };

            AddEditItemDialog dialog = new AddEditItemDialog()
            {
                DataContext = vm,
            };

            await dialog.ShowAsync();
            switch (dialog.Result)
            {
                case AddEditItemDialogResult.Save:
                    SaveItem(vm);
                    break;
                case AddEditItemDialogResult.Delete:
                    Delete(vm);
                    break;
                default:
                    break;
            }
        }

        private async void OnReset()
        {
            var result = await new YesNoDialog("Reset", "Are you sure you want to reset the sheet?").ShowAsync();
            if(result == ContentDialogResult.Secondary)
            {
                Reset();
            }
        }

        #region Commands

        public ICommand EditItemCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Components

        private ValidationsViewModel _validations;
        [Embedded]
        public ValidationsViewModel Validations
        {
            get
            {
                return _validations;
            }
            set
            {
                _validations = value;
                OnPropertyChanged(nameof(Validations));
            }
        }

        #endregion
    }
}
