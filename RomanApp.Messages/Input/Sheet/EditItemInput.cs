using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    public abstract class EditItemInput: AddItemInput
    {


        #region Properties

        [Required(ValidationMessage = "sheet.add.edit.item.id.required")]
        public string ItemId
        {
            get;
            set;
        }

        #endregion
    }
}
