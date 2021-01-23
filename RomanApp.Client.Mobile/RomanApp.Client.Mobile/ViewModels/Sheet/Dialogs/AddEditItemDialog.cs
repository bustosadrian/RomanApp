using RomanApp.Client.Mobile.Utils;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Messages;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs
{
    public class AddEditItemDialog : ContentDialog
    {
        public AddEditItemDialog(KeyboardMode keyboardMode, ItemType itemType, bool isDeleteEnabled)
            : this(keyboardMode, null, itemType, isDeleteEnabled, null, "0")
        {

        }

        public AddEditItemDialog(KeyboardMode keyboardMode, string id, ItemType itemType, bool isEditing, string name, string amount)
            : base()
        {
            ViewModel = new AddEditItemViewModel(keyboardMode, id, itemType, isEditing)
            {
                Name = name,
                Amount = amount,
            };

            Content = new AddEditItem()
            {
                BindingContext = ViewModel,
            };

            if (isEditing)
            {
                AddButton(new ContentDialogButton() { Icon = Icons.TrashAltSolid, Color = Color.Red, Result = AddEditItemResult.Delete });
            }
            AddButton(new ContentDialogButton() { Icon = Icons.TimesCircleRegular, Color = Color.White, Result = AddEditItemResult.Cancel, IsBack = true, });
            AddButton(new ContentDialogButton() { Icon = Icons.CheckCircleRegular, Color = Color.Lime, Result = AddEditItemResult.Ok, CloseDialog = false });
        }

        #region Properties
        public AddEditItemViewModel ViewModel
        {
            get;
            set;
        }

        #endregion
    }
}
