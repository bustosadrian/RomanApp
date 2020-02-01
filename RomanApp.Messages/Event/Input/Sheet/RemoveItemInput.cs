﻿using Reedoo.NET.Messages.Input;

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
