using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Controller.Entities
{
    public class BudgetOutcome
    {
        #region Properties

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

        public IEnumerable<GuestOutcome> Guests
        {
            get;
            set;
        }

        #endregion
    }
}
