using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class CollectedGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Collected";

        #region Properties

        public List<string> Debtors
        {
            get;
            set;
        }

        public decimal TotalCollected
        {
            get;
            set;
        }

        public List<NameAmountOutput> Creditors
        {
            get;
            set;
        }

        public bool HasExpenses
        {
            get;
            set;
        }

        #endregion
    }
}
