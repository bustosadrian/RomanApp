using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ControllerState(Key = KEY)]
    public class BudgetState : BaseMemberState
    {
        private const string KEY = "RomanApp.Offline.Budget";

        public override void Brief()
        {
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

        #region Properties

        [Reader]
        public void Read(NewItemMessage message)
        {
            ChangeState(typeof(CreateItemState));
        }

        #endregion
    }
}
