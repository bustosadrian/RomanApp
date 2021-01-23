using RomanApp.Service.Entities;
using RomanApp.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanApp.Service
{
    public class EventService : IEventService
    {
        private const int ROUND_INTERVAL = 1;

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

                int interval = useWholeNumbers ? 0 : ROUND_INTERVAL;

                retval.RealShare = retval.Total / (decimal)all.Count;
                retval.Share = Round(retval.RealShare, interval);

                foreach (var o in all)
                {
                    decimal debt = o.Amount - retval.Share;
                    decimal roundedDebt = Round(debt, interval);
                    decimal absDebt = Math.Abs(roundedDebt);
                    o.Debt = absDebt;
                    retval.LeftOver += Math.Abs(debt) - o.Debt;

                    if (roundedDebt > 0)
                    {
                        retval.TotalCreditors += o.Debt;
                        creditors.Add(o);
                    }
                    else if (roundedDebt < 0)
                    {
                        retval.TotalDebtors += o.Debt;
                        o.DebtorStatus = o.Amount == 0 ? GuestDebtorStatus.Full : GuestDebtorStatus.Partial;
                        debtors.Add(o);
                    }
                    else if (roundedDebt == 0)
                    {
                        evens.Add(o);
                    }
                }

                if (!debtors.Any())
                {
                    throw new OutcomeAnavailableException(OutcomeResult.NoDebtors);
                }

                retval.LeftOver = retval.TotalDebtors - retval.TotalCreditors - retval.TotalExpenses;
            }
            catch (OutcomeAnavailableException ex)
            {
                retval.Result = ex.Result;
            }

            return retval;
        }

        public decimal Round(decimal value, int interval)
        {
            decimal retval = 0;

            if (interval < 0 || interval > 99)
            {
                throw new ArgumentException("Must be between 0 and 99", nameof(interval));
            }

            int floating = Math.Abs((int)((value % 1) * 100));
            if (floating == 0)
            {
                retval = value;
            }
            else
            {
                decimal? roundedFLoating = null;
                int padLeft = 0;
                int padRight = floating; ;
                int closestLeft = 0;
                int closestRight = 0;
                for (int i = 0; i <= 100; i += (interval == 0 ? 100 : interval))
                {
                    if (i < floating)
                    {
                        padLeft = floating - i;
                        closestLeft = i;
                    }
                    else if (i > floating)
                    {
                        padRight = i - floating;
                        closestRight = i;
                        break;
                    }
                    else
                    {
                        roundedFLoating = i;
                        break;
                    }
                }

                if (!roundedFLoating.HasValue)
                {
                    if (padRight < padLeft)
                    {
                        roundedFLoating = closestRight;
                    }
                    else
                    {
                        roundedFLoating = closestLeft;
                    }
                }

                decimal retvalCents = roundedFLoating.Value / 100;
                if(value < 0)
                {
                    retval = Math.Truncate(value) - retvalCents;
                }
                else
                {
                    retval = Math.Truncate(value) + retvalCents;
                }
            }

            return retval;
        }

    }
}
