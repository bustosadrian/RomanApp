﻿using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet.Outcome
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeSummaryOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Summary";

        #region Properties

        public decimal TotalGuests
        {
            get;
            set;
        }

        public decimal TotalExpenses
        {
            get;
            set;
        }

        public decimal TotalDebtors
        {
            get;
            set;
        }

        public decimal TotalCreditors
        {
            get;
            set;
        }

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

        public bool UseWholeNumbers
        {
            get;
            set;
        }

        public decimal LeftOver
        {
            get;
            set;
        }

        #endregion
    }
}
