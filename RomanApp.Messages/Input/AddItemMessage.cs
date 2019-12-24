using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    public class AddItemMessage : InputMessage
    {
        #region Properties

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
