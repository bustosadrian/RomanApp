using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeTextOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text";

        #region Properties

        public TotalGroupOutput Total
        {
            get;
            set;
        }

        public ShareGroupOutput Share
        {
            get;
            set;
        }

        public DebtorsGroupOutput Debtors
        {
            get;
            set;
        }

        public CollectedGroupOutput Collected
        {
            get;
            set;
        }

        public ExpensesGroupOutput Expenses
        {
            get;
            set;
        }

        public EvensGroupOutput Evens
        {
            get;
            set;
        }

        #endregion
    }
}
