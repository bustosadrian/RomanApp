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

        public decimal TotalGuests
        {
            get;
            set;
        }

        public int GuestsCount
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

        public decimal Share
        {
            get;
            set;
        }

        public decimal RealShare
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

        public IEnumerable<ExpenseOutcome> Expenses
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
