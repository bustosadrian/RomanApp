using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Entities;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.MemberStates
{
    public abstract class BaseMemberState : MemberState
    {

        #region Messages

        [Reader]
        public void Read(LogOutMessage message)
        {
            Evict(null);
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

        protected BudgetOutcome BudgetOutcome
        {
            get
            {
                return RoomLocker.Get<BudgetOutcome>(RoomHandler.LOCKER_BUDGET_OUTCOME);
            }
            set
            {
                RoomLocker.Add(RoomHandler.LOCKER_BUDGET_OUTCOME, value);
            }
        }

        #endregion

    }
}
