using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeMessage : OutputMessage
    {
        private const string KEY = "RomanApp.Outcome";

        #region Properties

        public decimal Total
        {
            get;
            set;
        }

        public decimal Share
        {
            get;
            set;
        }

        public decimal ExpnesesTotal
        {
            get;
            set;
        }
        
        public IEnumerable<GuestOutcomeMessage> Debtors
        {
            get;
            set;
        }

        public IEnumerable<GuestOutcomeMessage> Creditors
        {
            get;
            set;
        }

        public IEnumerable<GuestOutcomeMessage> Evens
        {
            get;
            set;
        }

        #endregion
    }
}
