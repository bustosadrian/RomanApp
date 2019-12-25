using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;
using System.Collections.Generic;

namespace RomanApp.Controller.Offline.MemberStates
{
    public abstract class OfflineState : BaseMemberState
    {

        protected void CalculateBudget()
        {
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
        }

        protected void GoToBudget()
        {
            ChangeState(typeof(BudgetState));
        }

        #region Messages

        [Reader]
        public virtual void Read(ResetMessage message)
        {
            Budget.Reset();
        }

        #endregion
    }
}
