using Microsoft.Extensions.Logging;
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
            base.Brief();
        }

        #region Messages

        [Reader]
        public void Read(AddGuestMessage message)
        {
            Guest guest = new Guest()
            {
                Label = message.Name,
                Amount = message.Amount,
            };
            Budget.Add(guest);
            Logger?.LogInformation("Guest \"{0}\" -> {1}", guest.Label, guest.Amount);

            CalculateBudget();

            GoToBudget();
        }

        [Reader]
        public void Read(AddExpenseMessage message)
        {
            Expense expense = new Expense()
            {
                Label = message.Name,
                Amount = message.Amount,
            };
            Budget.Add(expense);
            Logger?.LogInformation("Expense \"{0}\" -> {1}", expense.Label, expense.Amount);

            CalculateBudget();

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
