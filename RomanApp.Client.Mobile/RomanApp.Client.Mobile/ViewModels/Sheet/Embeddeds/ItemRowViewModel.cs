using RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Sheet.Embeddeds
{
    public class ItemRowViewModel : BaseItemRowViewModel
    {
        public ItemRowViewModel(BusViewModel parent)
            : base(parent)
        {
            EditCommand = new Command(OnEdit);
        }

        private async void OnEdit()
        {
            AddEditItemDialog dialog = new AddEditItemDialog(Type, false, Name, Amount);
            var result = await dialog.ShowAsync();

            switch (result)
            {
                case AddEditItemResult.Ok:
                    Edit(dialog.ViewModel);
                    break;
                case AddEditItemResult.Delete:
                    Delete();
                    break;
                default:
                    break;
            }
            
        }
    }
}
