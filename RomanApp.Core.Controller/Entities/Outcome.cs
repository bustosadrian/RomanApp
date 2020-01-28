using System.Collections.Generic;

namespace RomanApp.Core.Controller.Entities
{
    public class Outcome
    {
        #region Properties

        public bool IsEmpty
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal ExpensesTotal
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
