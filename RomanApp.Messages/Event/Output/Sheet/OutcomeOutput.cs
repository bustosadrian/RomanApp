using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Event.Sheet.Output";

        #region Properties

        public decimal Total
        {
            get;
            set;
        }

        public decimal ExpensesTotal
        {
            get;
            set;
        }

        public decimal Share
        {
            get;
            set;
        }

        public List<GuestOutcomeOutput> Creditors
        {
            get;
            set;
        }

        public List<GuestOutcomeOutput> Debtors
        {
            get;
            set;
        }

        public List<GuestOutcomeOutput> Evens
        {
            get;
            set;
        }

        #endregion
    }
}
