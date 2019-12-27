using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;
using System.Linq;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ApplicationState(Key = KEY)]
    public class OutcomeState : OfflineState
    {
        private const string KEY = "RomanApp.Offline.Outcome";

        public override void Brief()
        {
            base.Brief();

            OutcomeMessage message = new OutcomeMessage();

            message.Total = BudgetOutcome.Total;
            message.Share = BudgetOutcome.Share;
            message.ExpnesesTotal = BudgetOutcome.ExpensesTotal;

            message.Debtors = BudgetOutcome.Guests
                .Where(x => x.Status == GuestOutcomeStatus.DEBTOR).Select(x => Map(x));

            message.Creditors = BudgetOutcome.Guests
                .Where(x => x.Status == GuestOutcomeStatus.CREDITOR).Select(x => Map(x));

            message.Evens= BudgetOutcome.Guests
                .Where(x => x.Status == GuestOutcomeStatus.EVEN).Select(x => Map(x));

            Queue(message);
        }

        private GuestOutcomeMessage Map(GuestOutcome entity)
        {
            GuestOutcomeMessage retval = null;

            retval = new GuestOutcomeMessage()
            {
                Name = entity.Name,
                Amount = entity.Debt,
            };

            return retval;
        }

        #region Messages

        [Reader]
        public override void Read(ResetMessage message)
        {
            base.Read(message);
            GoToBudget();
        }

        [Reader]
        public void Read(BackMessage message)
        {
            GoToBudget();
        }

        #endregion
    }
}
