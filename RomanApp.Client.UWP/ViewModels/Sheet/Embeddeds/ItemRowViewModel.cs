using System;
using RomanApp.Client.UWP.Views.Event.Sheet.Controls;
using RomanApp.Client.UWP.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.ViewModels.Sheet.Embeddeds
{
    public class ItemRowViewModel : BaseItemRowViewModel
    {
        public ItemRowViewModel(BusViewModel parent) 
            : base(parent)
        {
            EditCommand = new XamlUICommand();
            ((XamlUICommand)EditCommand).ExecuteRequested += (s, e) => { OnEdit(); };
        }

        private async void OnEdit()
        {
            AddEditItemViewModel vm = new AddEditItemViewModel(Type, true)
            {
                Name = Name,
                Amount = Amount,
            };
            AddEditItemDialog dialog = new AddEditItemDialog()
            {
                DataContext = vm,
            };

            await dialog.ShowAsync();
            switch (dialog.Result)
            {
                case AddEditItemDialogResult.Save:
                    Edit(vm);
                    break;
                case AddEditItemDialogResult.Delete:
                    Delete();
                    break;
                default:
                    break;
            }
        }
    }
}
