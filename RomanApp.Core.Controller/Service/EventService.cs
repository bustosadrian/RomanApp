using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RomanApp.Core.Controller.Entities;

namespace RomanApp.Core.Controller.Service
{
    public class EventService : IEventService
    {
        public Event Create(string name)
        {
            Event retval = null;

            retval = new Event();
            retval.Id = Guid.NewGuid().ToString();
            retval.DateCreated = DateTimeOffset.Now;
            retval.Name = name;

            return retval;
        }

        public Expense AddExpense(Event e, string label, decimal amount, string description)
        {
            Expense retval = null;

            retval = new Expense();
            retval.Id = Guid.NewGuid().ToString();
            retval.Label = label;
            retval.Share = CreateShare(amount, description);

            e.Expenses.Add(retval);

            return retval;
        }

        public Guest AddGuest(Event e, string name, decimal amount, string description)
        {
            Guest retval = null;

            retval = new Guest();
            retval.Id = Guid.NewGuid().ToString();
            retval.Name = name;
            retval.Share = CreateShare(amount, description);

            e.Guests.Add(retval);

            return retval;
        }

        public bool RemoveExpense(Event e, string id)
        {
            bool retval = false;

            Expense o = e.Expenses.FirstOrDefault(x => x.Id == id);
            if(o != null)
            {
                retval = e.Expenses.Remove(o);
            }

            return retval;
        }

        public bool RemoveGuest(Event e, string id)
        {
            bool retval = false;

            Guest o = e.Guests.FirstOrDefault(x => x.Id == id);
            if (o != null)
            {
                retval = e.Guests.Remove(o);
            }

            return retval;
        }


        private Share CreateShare(decimal amount, string description)
        {
            Share retval = null;

            retval = new Share();
            retval.Id = Guid.NewGuid().ToString();
            retval.Amount = amount;
            retval.Description = description;

            return retval;
        }
    }
}
