using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ControllerState(Key = KEY)]
    public class CreateItemState : OfflineState
    {
        private const string KEY = "RomanApp.Offline.Create.Item";

        public override void Brief()
        {

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

            CalculateBudget();

            GoToBudget();
        }

        [Reader]
        public void Read(AddExpenseMessage message)
        {
            Budget.Add(new Expense()
            {
                Label = message.Name,
                Amount = message.Amount,
            });
            GoToBudget();
        }

        [Reader]
        public void Read(CancelMessage message)
        {
            GoToBudget();
        }

        [Reader]
        public override void Read(ResetMessage message)
        {
            base.Read(message);
            GoToBudget();
        }

        #endregion

    }
}
