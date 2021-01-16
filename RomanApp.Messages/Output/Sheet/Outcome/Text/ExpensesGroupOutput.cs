using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class ExpensesGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Expenses";

        #region Properties

        public bool HasCreditors
        {
            get;
            set;
        }

        public decimal Remaining
        {
            get;
            set;
        }

        public List<string> Debtors
        {
            get;
            set;
        }

        public List<NameAmountOutput> Expenses
        {
            get;
            set;
        }

        #endregion

    }
}
