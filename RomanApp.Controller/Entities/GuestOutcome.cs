using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Controller.Entities
{
    public class GuestOutcome
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public decimal Debt
        {
            get;
            set;
        }

        public GuestOutcomeStatus Status
        {
            get;
            set;
        }

        #endregion
    }

    public enum GuestOutcomeStatus
    {
        DEBTOR, CREDITOR, EVEN
    }
}
