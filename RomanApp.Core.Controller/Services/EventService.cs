using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.Services.Exceptions;

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

        public Outcome Calculate(Event e)
        {
            Outcome retval = null;

            List<GuestOutcome> creditors = new List<GuestOutcome>();
            List<GuestOutcome> debtors = new List<GuestOutcome>();
            List<GuestOutcome> evens = new List<GuestOutcome>();
            retval = new Outcome()
            {
                Creditors = creditors,
                Debtors = debtors,
                Evens = evens,
            };

            retval.ExpensesTotal = e.Expenses.Sum(x => x.Share.Amount);
            retval.Total = retval.ExpensesTotal;

            List<GuestOutcome> all = new List<GuestOutcome>();
            foreach(var o in e.Guests)
            {
                retval.Total += o.Share.Amount;
                all.Add(new GuestOutcome()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Amount = o.Share.Amount,
                });
            }

            if(retval.Total == 0)
            {
                throw new OutcomeTotalZeroException();
            }

            retval.Share = retval.Total / all.Count;

            foreach (var o in all)
            {
                o.Debt = o.Amount - retval.Share;
                if (o.Debt > 0)
                {
                    creditors.Add(o);
                }
                else if (o.Debt < 0)
                {
                    debtors.Add(o);
                }
                else if (o.Debt == 0)
                {
                    evens.Add(o);
                }
            }

            return retval;
        }
    }
}
