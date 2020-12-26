using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public  class EditItemInput: AddItemInput
    {
        private const string KEY = "RomanApp.Sheet.Input.Edit.Item";

        #region Properties

        public string ItemId
        {
            get;
            set;
        }

        #endregion
    }
}
