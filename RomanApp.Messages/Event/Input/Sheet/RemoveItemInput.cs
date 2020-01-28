using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    public abstract class RemoveItemInput : InputMessage
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
