using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Controller.Entities
{
    public class Budget
    {
        public Budget()
        {
            _expenses = new List<Expense>();

            _guests = new List<Guest>();
        }

        public void Reset()
        {
            _expenses.Clear();

            _guests.Clear();
        }

        public void Add(Guest guest)
        {
            _guests.Add(guest);
        }

        public void Add(Expense expense)
        {
            _expenses.Add(expense);
        }

        #region Properties

        private List<Expense> _expenses;
        public IEnumerable<Expense> Expenses
        {
            get
            {
                return _expenses;
            }
        }

        private List<Guest> _guests;
        public IEnumerable<Guest> Guests
        {
            get
            {
                return _guests;
            }
        }

        #endregion
    }
}
