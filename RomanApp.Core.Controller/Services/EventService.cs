using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RomanApp.Core.Controller.Entities;

namespace RomanApp.Core.Controller.Services
{
    public class EventService : IEventService
    {
        public Event Create(string name)
        {
            Event retval = null;

            retval = new Event
            {
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTimeOffset.Now,
                Name = name,
                Guests = new List<Guest>(),
                Expenses = new List<Expense>(),
            };

            return retval;
        }

        public Expense AddExpense(Event e, string label, decimal amount, string description)
        {
            Expense retval = null;

            retval = new Expense
            {
                Id = Guid.NewGuid().ToString(),
                Label = label,
                Share = CreateShare(amount, description)
            };

            e.Expenses.Add(retval);

            return retval;
        }

        public Guest AddGuest(Event e, string name, decimal amount, string description)
        {
            Guest retval = null;

            retval = new Guest
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Share = CreateShare(amount, description)
            };

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

            retval = new Share
            {
                Id = Guid.NewGuid().ToString(),
                Amount = amount,
                Description = description
            };

            return retval;
        }
    }
}
