using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.Offline.States;
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

        #endregion

        #region Properties

        protected BaseState BaseState
        {
            get
            {
                return (BaseState)GetRoomState();
            }
        }

        #endregion

    }
}
