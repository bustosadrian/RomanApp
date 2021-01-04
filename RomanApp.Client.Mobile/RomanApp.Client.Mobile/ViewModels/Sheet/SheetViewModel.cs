using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
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

            ResetCommand = new Command(
                execute: () => OnReset(),
                canExecute: () => IsResetEnabled
                );

            EditItemCommand = new Command<ItemRowViewModel>(OnItemSelected);
        }

        protected override void ChangeCanExecute(ICommand command)
        {
            ((Command)command).ChangeCanExecute();
        }

        protected override void OnNewItem(ItemType itemType)
        {
            _addEditItemDialog = new AddEditItemDialog(itemType, false);
            _addEditItemDialog.Show();
            WaitForAddEditItemResult();
        }

        private void OnItemSelected(ItemRowViewModel item)
        {
            _addEditItemDialog = new AddEditItemDialog(item.Id, item.Type, true, item.Name, item.Amount);
            _addEditItemDialog.Show();
            WaitForAddEditItemResult();
        }

        private async void CloseAddEditItemDialog()
        {
            await Navigation.PopModalAsync();

            _addEditItemDialog = null;
        }

        private async void OnReset()
        {
            var answer = await Application.Current.MainPage.DisplayAlert(
                RomanApp.Client.Mobile.Resx.Views.Sheet_Dialog_Reset_Header,
                RomanApp.Client.Mobile.Resx.Views.Sheet_Dialog_Reset_Verbiage,
                RomanApp.Client.Mobile.Resx.Views.Sheet_Dialog_Reset_Action_Yes,
                RomanApp.Client.Mobile.Resx.Views.Sheet_Dialog_Reset_Action_No);
            if (answer)
            {
                Reset();
            }
        }

        

        private async void WaitForAddEditItemResult()
        {
            var result = await _addEditItemDialog.Wait();

            switch (result)
            {
                case AddEditItemResult.Ok:
                    SaveItem(_addEditItemDialog.ViewModel);
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
                WaitForAddEditItemResult();
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
