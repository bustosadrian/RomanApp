using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUWP.Entities
{
    public class Budget
    {
        #region Properties

        public IEnumerable<Guest> Guests
        {
            get;
            set;
        }

        public IEnumerable<Expense> Expenses
        {
            get;
            set;
        }

        #endregion
    }
}
