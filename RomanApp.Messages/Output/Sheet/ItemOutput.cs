using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ItemOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Item";

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
