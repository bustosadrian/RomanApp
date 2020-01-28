using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    public abstract class RemoveItemOutput : OutputMessage
    {
        #region Properties

        public string ItemId
        {
            get;
            set;
        }

        #endregion
    }
}
