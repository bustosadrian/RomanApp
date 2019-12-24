using Reedoo.NET.Controller;
using RomanApp.Controller.Entities;

namespace RomanApp.Controller.Offline.MemberStates
{
    public abstract class BaseMemberState : MemberState
    {

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
