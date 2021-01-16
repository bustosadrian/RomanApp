using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class TotalGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Total";

        public TotalGroupOutput() 
        {

        }

        #region Properties

        public decimal Total
        {
            get;
            set;
        }

        public decimal TotalGuests
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
