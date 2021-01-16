using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class DebtorsGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Debtors";

        public DebtorsGroupOutput()
        {

        }


        #region Properties

        public decimal Share
        {
            get;
            set;
        }

        public List<string> FullDebtors
        {
            get;
            set;
        }


        public List<NameAmountOutput> PartialDebtors
        {
            get;
            set;
        }


        #endregion
    }
}
