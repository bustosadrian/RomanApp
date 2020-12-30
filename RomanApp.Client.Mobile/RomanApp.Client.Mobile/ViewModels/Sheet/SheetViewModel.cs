using Reedoo.NET.Client.Messages;
using RomanApp.Client.Mobile.Utils;
using RomanApp.Client.Mobile.ViewModels.Components;
using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.ViewModels.Sheet.Embeddeds;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Client.XAML.ViewModels.Sheet;
using RomanApp.Messages;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Sheet
{
    public class SheetViewModel : BaseSheetViewModel
    {
        public SheetViewModel()
            : base()
        {
            GoToSettingsCommand = new Command(OnGoToSettings);

            GoToHelpCommand = new Command(OnGoToHelp);

            NewGuestCommand = new Command(OnNewGuest);

            NewExpenseCommand = new Command(OnNewExpense);

            ResetCommand = new Command(OnReset);

            Validations = new ValidationsViewModel(this);
        }

        protected override BaseItemRowViewModel NewItemRow()
        {
            return new ItemRowViewModel(this);
        }

        protected override async void OnNewItem(ItemType itemType)
        {
            AddEditItemDialog dialog = new AddEditItemDialog(itemType, false);
            var result = await dialog.ShowAsync();

            switch (result)
            {
                case AddEditItemResult.Ok:
                    AddItem(dialog.ViewModel);
                    break;
                default:
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
