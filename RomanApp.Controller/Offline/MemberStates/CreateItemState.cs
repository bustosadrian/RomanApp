using Microsoft.Extensions.Logging;
using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.MemberStates
{
    [ApplicationState(KEY)]
    public class CreateItemState : OfflineState
    {
        private const string KEY = "RomanApp.Offline.Create.Item";

        public override void Brief()
        {
            base.Brief();
        }

        #region Messages

        [Reader]
        public void Read(AddGuestMessage message)
        {
            AddGuest(message.Name, message.Amount);
            GoToBudget();
        }

        [Reader]
        public void Read(AddExpenseMessage message)
        {
            AddExpense(message.Name, message.Amount);
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
