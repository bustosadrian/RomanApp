using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class RemoveItemOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Remove.Item";

        #region Properties

        public string Id
        {
            get;
            set;
        }

        public ItemType Type
        {
            get;
            set;
        }

        #endregion
    }
}
