using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Output.Sheet.Outcome
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeGuestsOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Guests";

        #region Properties

        public List<OutcomeGuestOutput> Debtors
        {
            get;
            set;
        }

        public List<OutcomeGuestOutput> Creditors
        {
            get;
            set;
        }

        public List<OutcomeGuestOutput> Evens
        {
            get;
            set;
        }

        #endregion
    }
}
