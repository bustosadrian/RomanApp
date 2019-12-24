using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Controller.Entities;
using RomanApp.Controller.Offline.MemberStates;

namespace RomanApp.Controller.Offline.States
{
    public abstract class BaseState : RoomState
    {
        public override AlienTicket OnJoined(Passport passport)
        {
            AlienTicket retval = null;

            retval = new MemberTicket(passport, CreateMember());

            return retval;
        }

        public override MemberState OnJoined(IMember member)
        {
            BaseMemberState retval = null;

            retval = new BudgetState();

            return retval;
        }

        #region Locker

        public Budget Budget
        {
            get
            {
                return RoomLocker.Get<Budget>(RoomHandler.LOCKER_BUDGET);
            }
        }

        #endregion
    }
}
