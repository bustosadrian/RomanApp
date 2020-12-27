using Reedoo.NET.Client.Messages;
using RomanApp.Client.UWP.Dialogs;
using RomanApp.Client.UWP.ViewModels.Components;
using RomanApp.Client.UWP.ViewModels.Sheet.Embeddeds;
using RomanApp.Client.UWP.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
using System;
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

            GoToHelpCommand = new XamlUICommand();
            ((XamlUICommand)GoToHelpCommand).ExecuteRequested += (s, e) => {
                OnGoToHelp();
            };

            NewItemCommand = new XamlUICommand();
            ((XamlUICommand)NewItemCommand).ExecuteRequested += (s, e) => { 
                OnNewItem(Enum.Parse<ItemType>(e.Parameter.ToString())); 
            };

            ResetCommand = new XamlUICommand();
            ((XamlUICommand)ResetCommand).ExecuteRequested += (s, e) => {
                OnReset();
            };

            Validations = new ValidationsViewModel(this);
        }

        protected override BaseItemRowViewModel NewItemRow()
        {
            return new ItemRowViewModel(this);
        }

        private async void OnNewItem(ItemType itemType)
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
                    AddItem(vm);
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
