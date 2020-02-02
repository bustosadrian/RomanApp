﻿using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.Services.Exceptions;
using RomanApp.Core.Controller.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Label = name,
                Share = CreateShare(amount, description)
            };

            e.Guests.Add(retval);

            return retval;
        }

        public Share UpdateGuestContribution(Event e, Guest guest, Share share)
        {
            Share retval = null;

            int indexOf = e.Guests.IndexOf(guest);
            if(indexOf != -1)
            {
                retval = CreateShare(share.Amount, share.Description);
                e.Guests[indexOf].Share = retval;
            }

            return retval;
        }

        public Share UpdateExpenseAmount(Event e, Expense expense, Share share)
        {
            Share retval = null;

            int indexOf = e.Expenses.IndexOf(expense);
            if (indexOf != -1)
            {
                retval = CreateShare(share.Amount, share.Description);
                e.Expenses[indexOf].Share = retval;
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

        public Outcome Calculate(Event e)
        {
            Outcome retval = null;

            List<GuestOutcome> creditors = new List<GuestOutcome>();
            List<GuestOutcome> debtors = new List<GuestOutcome>();
            List<GuestOutcome> evens = new List<GuestOutcome>();
            retval = new Outcome()
            {
                IsEmpty = false,
                Creditors = creditors,
                Debtors = debtors,
                Evens = evens,
            };

            try
            {
                if(e.Guests.Count() < 2)
                {
                    throw new EmptyOutcomeException();
                }

                retval.ExpensesTotal = e.Expenses.Sum(x => x.Share.Amount);
                retval.Total = retval.ExpensesTotal;

                List<GuestOutcome> all = new List<GuestOutcome>();
                foreach (var o in e.Guests.Where(x => x.Share != null))
                {
                    retval.Total += o.Share.Amount;
                    all.Add(new GuestOutcome()
                    {
                        Id = o.Id,
                        Name = o.Label,
                        Amount = o.Share.Amount,
                    });
                }

                if (retval.Total == 0)
                {
                    throw new EmptyOutcomeException();
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

                Round(retval.Share, (List<GuestOutcome>)retval.Creditors, e.IsWholeNumbers);
                Round(retval.Share, (List<GuestOutcome>)retval.Debtors, e.IsWholeNumbers);
                //Round(retval.Share, (List<GuestOutcome>)retval.Evens, e.IsWholeNumbers);

                retval.Share = retval.Share.RoundCents(e.IsWholeNumbers);

                if (!debtors.Any())
                {
                    throw new EmptyOutcomeException();
                }
            }
            catch (EmptyOutcomeException)
            {
                retval.IsEmpty = true;
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
