using RomanApp.Service.Entities;
using RomanApp.Service.Exceptions;
using RomanApp.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanApp.Service
{
    public class EventService : IEventService
    {
        public Event Create()
        {
            Event retval = null;

            retval = new Event
            {
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTimeOffset.Now,
                Guests = new List<Guest>(),
                Expenses = new List<Expense>(),
            };

            return retval;
        }

        public Guest AddGuest(Event e, string name, decimal amount)
        {
            Guest retval = null;

            retval = new Guest
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Share = CreateShare(amount, null)
            };

            e.Guests.Add(retval);

            return retval;
        }

        public Expense AddExpense(Event e, string label, decimal amount)
        {
            Expense retval = null;

            retval = new Expense
            {
                Id = Guid.NewGuid().ToString(),
                Name = label,
                Share = CreateShare(amount, null)
            };

            e.Expenses.Add(retval);

            return retval;
        }

        public Guest UpdateGuest(Event e, string id, string name, decimal amount)
        {
            Guest retval = null;

            retval = e.Guests.SingleOrDefault(x => x.Id.Equals(id));
            if(retval != null)
            {
                retval.Name = name;
                retval.Share.Amount = amount;
            }

            return retval;
        }

        public Expense UpdateExpense(Event e, string id, string name, decimal amount)
        {
            Expense retval = null;

            retval = e.Expenses.SingleOrDefault(x => x.Id.Equals(id));
            if (retval != null)
            {
                retval.Name = name;
                retval.Share.Amount = amount;
            }

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

        public Outcome Calculate(Event e, bool useWholeNumbers)
        {
            Outcome retval = null;

            List<GuestOutcome> creditors = new List<GuestOutcome>();
            List<GuestOutcome> debtors = new List<GuestOutcome>();
            List<GuestOutcome> evens = new List<GuestOutcome>();
            retval = new Outcome()
            {
                Result = OutcomeResult.Ready,
                Creditors = creditors,
                Debtors = debtors,
                Evens = evens,
            };

            try
            {
                if(e.Guests.Count() < 2)
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NotEnoughGuests);
                }

                retval.TotalExpenses = e.Expenses.Sum(x => x.Share.Amount);
                retval.Total = retval.TotalExpenses;

                List<GuestOutcome> all = new List<GuestOutcome>();
                foreach (var o in e.Guests.Where(x => x.Share != null))
                {
                    retval.Total += o.Share.Amount;
                    all.Add(new GuestOutcome()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Amount = o.Share.Amount,
                    });
                }

                if (retval.Total == 0)
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NoTotal);
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
                    o.Debt = Math.Abs(o.Debt);
                }

                Round(retval.Share, (List<GuestOutcome>)retval.Creditors, useWholeNumbers);
                Round(retval.Share, (List<GuestOutcome>)retval.Debtors, useWholeNumbers);
                //Round(retval.Share, (List<GuestOutcome>)retval.Evens, e.IsWholeNumbers);

                retval.Share = retval.Share.RoundCents(useWholeNumbers);

                if (!debtors.Any())
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NoDebtors);
                }
            }
            catch (OutcomeAnavailableException ex)
            {
                retval.Result = ex.Result;
            }

            return retval;
        }

        private void Round(decimal share, List<GuestOutcome> guests, bool wholeNumbers)
        {
            Round(share, 0, guests, wholeNumbers);
        }

        private void Round(decimal share, decimal expenses, List<GuestOutcome> guests, bool wholeNumbers)
        {
            decimal total = guests.Sum(x => x.Debt) + expenses;
            if (guests.Any())
            {
                decimal roundedTotal = 0;
                foreach (var o in guests)
                {
                    o.Debt = o.Debt.RoundCents(wholeNumbers);
                    roundedTotal += o.Debt;
                }
                decimal residual = total - roundedTotal;
                int it = new Random().Next(0, guests.Count);
                guests[it].Debt += residual;
                guests[it].Debt = guests[it].Debt.RoundCents(wholeNumbers);
            }

        }

    }
}
