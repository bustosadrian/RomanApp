using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class YourContributionOutput : RemoveItemOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Your.Contribution";

        #region Properties

        public decimal Amount
        {
            get;
            set;
        }

        #endregion

    }
}
