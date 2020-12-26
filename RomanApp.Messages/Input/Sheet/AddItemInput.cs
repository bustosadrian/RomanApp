using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
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

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }


        #endregion
    }
}
