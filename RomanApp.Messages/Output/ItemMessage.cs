using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output
{
    [Serializable]
    public abstract class ItemMessage : OutputMessage
    {
        #region Properties

        public string Label
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
