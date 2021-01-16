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
        private Event _event;

        public Event Create()
        {
            _event = null;

            _event = new Event
            {
                Id = Guid.NewGuid().ToString(),
                DateCreated = DateTime.Now,
                Guests = new List<Guest>(),
                Expenses = new List<Expense>(),
            };

            return _event;
        }

        public Guest AddGuest(string eventId, string id, string name, decimal amount)
        {
            Guest retval = null;

            retval = new Guest
            {
                Id = id ?? Guid.NewGuid().ToString(),
                Name = name,
                Amount = amount,
            };

            _event.Guests.Add(retval);

            return retval;
        }

        public Expense AddExpense(string eventId, string id, string label, decimal amount)
        {
            Expense retval = null;

            retval = new Expense
            {
                Id = id ?? Guid.NewGuid().ToString(),
                Name = label,
                Amount = amount,
            };

            _event.Expenses.Add(retval);

            return retval;
        }

        public Guest UpdateGuest(string eventId, string id, string name, decimal amount)
        {
            Guest retval = null;

            retval = _event.Guests.SingleOrDefault(x => x.Id.Equals(id));
            if (retval != null)
            {
                retval.Name = name;
                retval.Amount = amount;
            }

            return retval;
        }

        public Expense UpdateExpense(string eventId, string id, string name, decimal amount)
        {
            Expense retval = null;

            retval = _event.Expenses.SingleOrDefault(x => x.Id.Equals(id));
            if (retval != null)
            {
                retval.Name = name;
                retval.Amount = amount;
            }

            return retval;
        }

        public bool RemoveExpense(string eventId, string id)
        {
            bool retval = false;

            Expense o = _event.Expenses.FirstOrDefault(x => x.Id == id);
            if (o != null)
            {
                retval = _event.Expenses.Remove(o);
            }

            return retval;
        }

        public bool RemoveGuest(string eventId, string id)
        {
            bool retval = false;

            Guest o = _event.Guests.FirstOrDefault(x => x.Id == id);
            if (o != null)
            {
                retval = _event.Guests.Remove(o);
            }

            return retval;
        }

        public Outcome Calculate(string eventId, bool useWholeNumbers)
        {
            Outcome retval = null;

            List<GuestOutcome> creditors = new List<GuestOutcome>();
            List<GuestOutcome> debtors = new List<GuestOutcome>();
            List<GuestOutcome> evens = new List<GuestOutcome>();
            List<ExpenseOutcome> expenses = new List<ExpenseOutcome>();
            retval = new Outcome()
            {
                Result = OutcomeResult.Ready,
                Creditors = creditors,
                Debtors = debtors,
                Evens = evens,
                Expenses = expenses,
            };

            try
            {
                if (_event.Guests.Count() < 2)
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NotEnoughGuests);
                }

                retval.TotalGuests = _event.Guests.Sum(x => x.Amount);

                foreach(var o in _event.Expenses)
                {
                    retval.TotalExpenses += o.Amount;
                    expenses.Add(new ExpenseOutcome()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Amount = o.Amount,
                    });
                }

                retval.TotalExpenses = _event.Expenses.Sum(x => x.Amount);
                retval.Total = retval.TotalGuests + retval.TotalExpenses;

                List<GuestOutcome> all = _event.Guests.Select(x => new GuestOutcome()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amount = x.Amount,
                }).ToList();
                retval.GuestsCount = all.Count();

                if (retval.Total == 0)
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NoTotal);
                }

                retval.Share = retval.Total / all.Count;

                foreach (var o in all)
                {
                    decimal debt = (o.Amount - retval.Share).RoundCents(useWholeNumbers);
                    o.Debt = Math.Abs(debt);
                    if (debt > 0)
                    {
                        retval.TotalCreditors += o.Debt;
                        creditors.Add(o);
                    }
                    else if (debt < 0)
                    {
                        retval.TotalDebtors += o.Debt;
                        debtors.Add(o);
                    }
                    else if (debt == 0)
                    {
                        evens.Add(o);
                    }
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
                int it = new Random().Next(0, guests.Count());
                guests[it].Debt += residual;
                guests[it].Debt = guests[it].Debt.RoundCents(wholeNumbers);
            }
        }

    }
}
