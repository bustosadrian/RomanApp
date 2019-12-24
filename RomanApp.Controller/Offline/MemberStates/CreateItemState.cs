using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ControllerState(Key = KEY)]
    public class CreateItemState : BaseMemberState
    {
        private const string KEY = "RomanApp.Offline.Create.Item";

        public override void Brief()
        {

        }

        private void GoBack()
        {
            ChangeState(typeof(BudgetState));
        }

        #region Messages

        [Reader]
        public void Read(AddGuestMessage message)
        {
            Budget.Add(new Guest()
            {
                Label = message.Name,
                Amount = message.Amount,
            });
            GoBack();
        }

        [Reader]
        public void Read(AddExpenseMessage message)
        {
            Budget.Add(new Expense()
            {
                Label = message.Name,
                Amount = message.Amount,
            });
            GoBack();
        }

        [Reader]
        public void Read(CancelMessage message)
        {
            GoBack();
        }

        #endregion

    }
}
