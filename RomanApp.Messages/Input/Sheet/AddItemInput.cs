using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class AddItemInput : InputMessage
    {
        private const string KEY = "RomanApp.Sheet.Input.Add.Item";

        #region Properties

        public ItemType Type
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Range(GreaterThan = -1, ValidationMessage = "Must be greater or equal than zero")]
        public decimal Amount
        {
            get;
            set;
        }


        #endregion
    }
}
