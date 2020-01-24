using Microsoft.Extensions.Logging;
using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Controller.Entities;
using RomanApp.Controller.Offline.Gate;
using RomanApp.Controller.Offline.MemberStates;
using System;
using System.Collections.Generic;

namespace RomanApp.Controller.Offline.States
{
    public abstract class BaseState : RoomState
    {
        private GateTicket WriteAlienTicket(Passport passport)
        {
            GateTicket retval = null;

            retval = new GateTicket(passport, typeof(LoginGate));

            return retval;
        }

        #region Overriden

        public override AlienTicket OnJoined(Passport passport)
        {
            return WriteAlienTicket(passport);
        }

        public override MemberTicket OnJoined(Passport passport, TrespasserId trespasserId)
        {
            MemberTicket retval = null;

            LoginId loginId = (LoginId)trespasserId;

            IMember member = CreateMember(passport);
            member.Locker.Add(RoomHandler.LOCKER_MEMBER_NAME, loginId.Name);
            retval = new MemberTicket(passport, member);

            AddGuest(loginId.Name, loginId.Share.Amount);

            return retval;
        }

        public void AddGuest(string name, decimal amount)
        {
            Guest guest = new Guest()
            {
                Label = name,
                Amount = amount,
            };
            Budget.Add(guest);
            Logger?.LogInformation("Guest \"{0}\" -> {1}", guest.Label, guest.Amount);
            CalculateBudget();
        }

        public void AddExpense(string label, decimal amount)
        {
            Expense expense = new Expense()
            {
                Label = label,
                Amount = amount,
            };
            Budget.Add(expense);
            Logger?.LogInformation("Expense \"{0}\" -> {1}", expense.Label, expense.Amount);

            CalculateBudget();
        }

        public void ResetBudget()
        {
            Logger?.LogInformation("Reseting budget...");
            Budget.Reset();
        }

        public void CalculateBudget()
        {
            Logger?.LogInformation("Calculating budget...");
            BudgetOutcome outcome = new BudgetOutcome();

            Budget budget = Budget;

            foreach (var o in budget.Expenses)
            {
                outcome.ExpensesTotal += o.Amount;
            }
            outcome.Total = outcome.ExpensesTotal;

            List<GuestOutcome> all = new List<GuestOutcome>();
            foreach (var o in budget.Guests)
            {
                outcome.Total += o.Amount;
                all.Add(new GuestOutcome()
                {
                    Name = o.Label,
                    Amount = o.Amount,
                });
            }

            if (outcome.Total == 0)
            {
                return;
            }

            outcome.Share = outcome.Total / all.Count;

            foreach (var o in all)
            {
                o.Debt = o.Amount - outcome.Share;
                if (o.Debt < 0)
                {
                    o.Status = GuestOutcomeStatus.DEBTOR;
                }
                else if (o.Debt > 0)
                {
                    o.Status = GuestOutcomeStatus.CREDITOR;
                }
                else if (o.Debt == 0)
                {
                    o.Status = GuestOutcomeStatus.EVEN;
                }
            }
            outcome.Guests = all;

            BudgetOutcome = outcome;
            Logger?.LogInformation("Outcome:");
            Logger?.LogInformation("\t- Total: {0}", outcome.Total);
            Logger?.LogInformation("\t- Share: {0}", outcome.Share);
            Logger?.LogInformation("\t- Expenses: {0}", outcome.ExpensesTotal);
            Logger?.LogInformation("\t- Guests:");
            foreach (var o in outcome.Guests)
            {
                Logger?.LogInformation("\t\t- \"{0}\" [{1}]: {2}", o.Name, o.Status, o.Amount);
            }
        }


        public override Type OnJoined(IMember member)
        {
            return typeof(BudgetState);
        }

        protected override GateTicket OnMemberEvicted(IMember member, object reason)
        {
            return WriteAlienTicket(member.Passport);
        }

        #endregion

        #region Locker

        public Budget Budget
        {
            get
            {
                return RoomLocker.Get<Budget>(RoomHandler.LOCKER_BUDGET);
            }
        }

        protected BudgetOutcome BudgetOutcome
        {
            get
            {
                return RoomLocker.Get<BudgetOutcome>(RoomHandler.LOCKER_BUDGET_OUTCOME);
            }
            set
            {
                RoomLocker.Add(RoomHandler.LOCKER_BUDGET_OUTCOME, value);
            }
        }

        #endregion
    }
}
