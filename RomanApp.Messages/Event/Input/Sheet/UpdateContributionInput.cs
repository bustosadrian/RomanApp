using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    public abstract class UpdateContributionInput : InputMessage
    {
        #region Properties

        public decimal Amount
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        #endregion
    }
}
