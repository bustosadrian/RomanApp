using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
using RomanApp.Messages.Output.Sheet;
using System;
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

            GoToAboutCommand = new Command(OnGoToAbout);

            GetHelpCommand = new Command(OnGetHelp);

            NewGuestCommand = new Command(OnNewGuest);

            NewExpenseCommand = new Command(OnNewExpense);

            ResetCommand = new Command(
                execute: () => OnReset(),
                canExecute: () => IsResetEnabled
                );

            EditItemCommand = new Command<ItemRowViewModel>(OnEditCommand);
        }

        protected override void ChangeCanExecute(ICommand command)
        {
            try
            {
                ((Command)command).ChangeCanExecute();
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        protected override void OnNewItem(ItemType itemType)
        {
            if(_addEditItemDialog == null)
            {
                _addEditItemDialog = new AddEditItemDialog(itemType, false);
                _addEditItemDialog.OnError += AddEditItemDialog_OnError;
                _addEditItemDialog.Show();
                WaitForAddEditItemResult();
            }
        }


        private async void CloseAddEditItemDialog()
        {
            try
            {
                _addEditItemDialog = null;
                await Navigation.PopModalAsync();
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        private async void OnReset()
        {
            try
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
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        

        private async void WaitForAddEditItemResult()
        {
            try
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
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        private void AddEditItemDialog_OnError(object sender, System.IO.ErrorEventArgs e)
        {
            _addEditItemDialog = null;
            HandleError(e.GetException());
        }

        #region Command Methods

        private void OnEditCommand(ItemRowViewModel item)
        {
            try
            {
                if (_addEditItemDialog == null)
                {
                    _addEditItemDialog = new AddEditItemDialog(item.Id, item.Type, true, item.Name, item.Amount);
                    _addEditItemDialog.OnError += AddEditItemDialog_OnError;
                    _addEditItemDialog.Show();
                    WaitForAddEditItemResult();
                }
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        #endregion

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
