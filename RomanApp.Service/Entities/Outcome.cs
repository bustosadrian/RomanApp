using System.Collections.Generic;

namespace RomanApp.Service.Entities
{
    public class Outcome
    {
        #region Properties

        public OutcomeResult Result
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal TotalExpenses
        {
            get;
            set;
        }

        public decimal Share
        {
            get;
            set;
        }

        public IEnumerable<GuestOutcome> Debtors
        {
            get;
            set;
        }

        public IEnumerable<GuestOutcome> Creditors
        {
            get;
            set;
        }

        public IEnumerable<GuestOutcome> Evens
        {
            get;
            set;
        }

        #endregion
    }
}
