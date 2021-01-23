using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Validations;
using RomanApp.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class EditGuestInput : EditItemInput
    {
        private const string KEY = "RomanApp.Sheet.Input.Edit.Guest";

        #region Properties

        [Required(ValidationMessage = "sheet.add.edit.guest.name.required")]
        public override string Name
        {
            get;
            set;
        }

        [Required(ValidationMessage = "sheet.add.edit.guest.amount.required")]
        //[Range(GreaterThan = -1, ValidationMessage = "sheet.add.edit.guest.amount.range")]
        [ItemAmountValidation(GreaterThanZero = false)]
        public override string Amount
        {
            get;
            set;
        }

        #endregion
    }
}
