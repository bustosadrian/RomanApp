using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    public abstract class ContributionOutput : OutputMessage
    {
        #region Properties

        public decimal Amount
        {
            get;
            set;
        }

        #endregion
    }
}
