using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class RemoveItemInput : InputMessage
    {
        private const string KEY = "RomanApp.Sheet.Input.Delete.Item";

        #region Properties

        public ItemType Type
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }


        #endregion
    }
}
