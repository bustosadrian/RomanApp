using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Controller.Entities;
using RomanApp.Controller.Offline.Gate;
using RomanApp.Controller.Offline.MemberStates;
using System;

namespace RomanApp.Controller.Offline.States
{
    public abstract class BaseState : RoomState
    {
        private GateTicket WriteAlienTicket(Passport passport)
        {
            GateTicket retval = null;

            retval = new GateTicket(passport, typeof(LoginGate));

            return retval;
        }

        #region Overriden

        public override AlienTicket OnJoined(Passport passport)
        {
            return WriteAlienTicket(passport);
        }

        public override MemberTicket OnJoined(Passport passport, TrespasserId trespasserId)
        {
            MemberTicket retval = null;

            LoginId loginId = (LoginId)trespasserId;

            IMember member = CreateMember(passport);
            member.Locker.Add(RoomHandler.LOCKER_MEMBER_NAME, loginId.Name);
            retval = new MemberTicket(passport, member);

            return retval;
        }

        public override Type OnJoined(IMember member)
        {
            return typeof(BudgetState);
        }

        protected override GateTicket OnMemberEvicted(IMember member, object reason)
        {
            return WriteAlienTicket(member.Passport);
        }

        #endregion

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
