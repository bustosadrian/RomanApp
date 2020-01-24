using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;

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

        protected void AddGuest(string name, decimal amount)
        {
            BaseState.AddGuest(name, amount);
        }

        protected void AddExpense(string label, decimal amount)
        {
            BaseState.AddExpense(label, amount);
        }

        protected void ResetBudget()
        {
            BaseState.ResetBudget();
        }

        protected void GoToBudget()
        {
            ChangeState(typeof(BudgetState));
        }

        #region Messages

        [Reader]
        public virtual void Read(ResetMessage message)
        {
            ResetBudget();
        }

        #endregion

        #region Locker

        protected Budget Budget
        {
            get
            {
                return RoomLocker.Get<Budget>(RoomHandler.LOCKER_BUDGET);
            }
        }

        #endregion
    }
}
