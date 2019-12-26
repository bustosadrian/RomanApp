using Microsoft.Extensions.Logging;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;
using System.Collections.Generic;

namespace RomanApp.Controller.Offline.MemberStates
{
    public abstract class OfflineState : BaseMemberState
    {
        public override void Brief()
        {
            Queue(new ProfileMessage()
            {
                Name = Member.Locker.Get<string>(RoomHandler.LOCKER_MEMBER_NAME),
            });
        }

        protected void CalculateBudget()
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

        protected void GoToBudget()
        {
            ChangeState(typeof(BudgetState));
        }

        #region Messages

        [Reader]
        public virtual void Read(ResetMessage message)
        {
            Logger?.LogInformation("Reseting budget...");
            Budget.Reset();
        }

        #endregion
    }
}
