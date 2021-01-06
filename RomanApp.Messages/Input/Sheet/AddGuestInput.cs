using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class AddGuestInput : AddItemInput
    {
        private const string KEY = "RomanApp.Sheet.Input.Add.Guest";

        #region Properties

        [Required(ValidationMessage = "sheet.add.edit.guest.name.required")]
        public override string Name
        {
            get;
            set;
        }

        [Required(ValidationMessage = "sheet.add.edit.guest.amount.required")]
        [Range(GreaterThan = -1, ValidationMessage = "sheet.add.edit.guest.amount.range")]
        public override decimal Amount
        {
            get;
            set;
        }

        #endregion
    }
}
