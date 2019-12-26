using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ControllerState(Key = KEY)]
    public class BudgetState : OfflineState
    {
        private const string KEY = "RomanApp.Offline.Budget";

        public override void Brief()
        {
            base.Brief();

            BriefGuests();
            BriefExpenses();
        }

        private void BriefGuests()
        {
            foreach(var o in Budget.Guests)
            {
                Queue(new GuestMessage()
                {
                    Label = o.Label,
                    Amount = o.Amount,
                });
            }
        }

        private void BriefExpenses()
        {
            foreach (var o in Budget.Expenses)
            {
                Queue(new ExpenseMessage()
                {
                    Label = o.Label,
                    Amount = o.Amount,
                });
            }
        }

        #region Messages

        [Reader]
        public void Read(NewItemMessage message)
        {
            ChangeState(typeof(CreateItemState));
        }

        [Reader]
        public override void Read(ResetMessage message)
        {
            base.Read(message);
            Queue(new ClearMessage());
        }

        [Reader]
        public void Read(CalculateMessage message)
        {
            ChangeState(typeof(OutcomeState));
        }

        #endregion
    }
}
