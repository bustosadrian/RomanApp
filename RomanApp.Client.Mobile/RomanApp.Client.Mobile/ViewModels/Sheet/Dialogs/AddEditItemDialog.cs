using RomanApp.Client.Mobile.Utils;
using RomanApp.Client.Mobile.Views.Sheet.Dialogs;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Client.Mobile.ViewModels.Sheet.Dialogs
{
    public class AddEditItemDialog : ContentDialog
    {
        public AddEditItemDialog(ItemType itemType, bool isDeleteEnabled)
            : this(itemType, isDeleteEnabled, null, 0)
        {

        }

        public AddEditItemDialog(ItemType itemType, bool isDeleteEnabled, string name, decimal amount)
            : base()
        {
            ViewModel = new AddEditItemViewModel(itemType, isDeleteEnabled)
            {
                Name = name,
                Amount = amount,
            };

            Content = new AddEditItem()
            {
                BindingContext = ViewModel,
            };

            if (isDeleteEnabled)
            {
                AddButton(new ContentDialogButton() { Text = "Delete", Result = AddEditItemResult.Delete });
            }
            AddButton(new ContentDialogButton() { Text = "Cancel", Result = AddEditItemResult.Cancel });
            AddButton(new ContentDialogButton() { Text = "Ok", Result = AddEditItemResult.Ok });
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
