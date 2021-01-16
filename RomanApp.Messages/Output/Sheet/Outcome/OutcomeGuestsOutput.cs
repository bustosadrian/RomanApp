using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.Sheet.Outcome
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeGuestsOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Guests";

        #region Properties

        public List<OutcomeItemOutput> Debtors
        {
            get;
            set;
        }

        public List<OutcomeItemOutput> Creditors
        {
            get;
            set;
        }

        public List<OutcomeItemOutput> Evens
        {
            get;
            set;
        }


        public List<OutcomeItemOutput> Expenses
        {
            get;
            set;
        }

        #endregion
    }
}
