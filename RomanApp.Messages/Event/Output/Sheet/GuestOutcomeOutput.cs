using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class GuestOutcomeOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Event.Sheet.Output.Guest";

        #region Properties

        public string Id
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

        public decimal Debt
        {
            get;
            set;
        }

        #endregion
    }
}
