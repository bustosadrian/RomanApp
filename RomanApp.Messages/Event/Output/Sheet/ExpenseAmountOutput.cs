using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ExpenseAmountOutput : ContributionOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Expense.Amount.Output";

        #region Properties

        public string ExpenseLabel
        {
            get;
            set;
        }

        #endregion
    }
}
