using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Messages.Output.Sheet;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Sheet.Embeddeds
{
    public class ItemRowViewModel : BaseItemRowViewModel
    {
        private AddEditItemDialog _addEditItemDialog;

        public ItemRowViewModel(BusViewModel parent)
            : base(parent)
        {
            EditCommand = new Command(OnEdit);
        }

        private void OnEdit()
        {
            _addEditItemDialog = new AddEditItemDialog(Id, Type, true, Name, Amount);
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
                    Edit(_addEditItemDialog.ViewModel);
                    break;
                case AddEditItemResult.Delete:
                    Delete();
                    CloseAddEditItemDialog();
                    break;
                case AddEditItemResult.Cancel:
                    CloseAddEditItemDialog();
                    break;
            }
        }

        #region Messages

        [Reader]
        public override bool Read(ValidationErrors message)
        {
            if(_addEditItemDialog != null)
            {
                if (_addEditItemDialog.ViewModel.ProcessValidationErrors(message.Errors) == true)
                {
                    WaitForNewItemResult();
                    return true;
                }
            }
            return false;
        }

        [Reader]
        public override bool Read(ItemSavedOutput message)
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
