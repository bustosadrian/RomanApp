using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.ViewModels.Sheet.Embeddeds;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using System.Windows.Input;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Sheet
{
    public class SheetViewModel : BaseSheetViewModel
    {
        private AddEditItemDialog _addEditItemDialog;

        public SheetViewModel()
            : base()
        {
            GoToSettingsCommand = new Command(OnGoToSettings);

            GoToHelpCommand = new Command(OnGoToHelp);

            NewGuestCommand = new Command(OnNewGuest);

            NewExpenseCommand = new Command(OnNewExpense);

            ResetCommand = new Command(OnReset);

            EditItemCommand = new Command(OnItemSelected);
        }

        private void Edit(AddEditItemViewModel viewModel)
        {
            EditItemInput message = new EditItemInput()
            {
                ItemId = viewModel.Id,
                Type = viewModel.ItemType,
                Name = viewModel.Name,
                Amount = viewModel.Amount,
            };
            Send(message);
        }

        private void Delete(AddEditItemViewModel viewModel)
        {
            Send(new RemoveItemInput()
            {
                ItemId = viewModel.Id,
                Type = viewModel.ItemType,
            });
        }

        protected override BaseItemRowViewModel NewItemRow()
        {
            return new ItemRowViewModel(this);
        }

        protected override void OnNewItem(ItemType itemType)
        {
            _addEditItemDialog = new AddEditItemDialog(itemType, false);
            _addEditItemDialog.Show();
            WaitForNewItemResult();
        }

        private async void CloseAddEditItemDialog()
        {
            await Navigation.PopModalAsync();

            _addEditItemDialog = null;
        }

        private async void WaitForNewItemResult()
        {
            var result = await _addEditItemDialog.Wait();

            switch (result)
            {
                case AddEditItemResult.Ok:
                    AddItem(_addEditItemDialog.ViewModel);
                    break;
                case AddEditItemResult.Cancel:
                    CloseAddEditItemDialog();
                    break;
            }
        }

        private async void OnReset()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Reset", "Are you sure you want to reset the sheet?", "Yes", "No");
            if (answer)
            {
                Reset();
            }
        }

        private void OnItemSelected(object parameter)
        {
            var item = (ItemRowViewModel)parameter;
            _addEditItemDialog = new AddEditItemDialog(item.Id, item.Type, true, item.Name, item.Amount);
            _addEditItemDialog.Show();
            WaitForEditItemResult();
        }

        private async void WaitForEditItemResult()
        {
            var result = await _addEditItemDialog.Wait();

            switch (result)
            {
                case AddEditItemResult.Ok:
                    Edit(_addEditItemDialog.ViewModel);
                    break;
                case AddEditItemResult.Delete:
                    Delete(_addEditItemDialog.ViewModel);
                    CloseAddEditItemDialog();
                    break;
                case AddEditItemResult.Cancel:
                    CloseAddEditItemDialog();
                    break;
            }
        }

        #region Commands

        public ICommand EditItemCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Messages

        [Reader]
        public bool Read(ValidationErrors message)
        {
            if (_addEditItemDialog?.ViewModel.ProcessValidationErrors(message.Errors) == true)
            {
                WaitForNewItemResult();
                return true;
            }
            return true;
        }

        [Reader]
        public bool Read(ItemSavedOutput message)
        {
            CloseAddEditItemDialog();

            return true;
        }

        #endregion

        #region Components

        #endregion

        #region Properties

        private INavigation Navigation
        {
            get
            {
                return Application.Current.MainPage.Navigation;
            }
        }

        #endregion
    }
}
