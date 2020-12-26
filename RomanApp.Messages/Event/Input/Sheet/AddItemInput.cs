using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    public abstract class AddItemInput : InputMessage
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

        public string Name
        {
            get;
            set;
        }

        #endregion
    }
}
