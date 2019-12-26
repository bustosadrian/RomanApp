using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Controller.Entities;
using RomanApp.Controller.Offline.Gate;
using RomanApp.Controller.Offline.MemberStates;
using RomanApp.Messages.Output;
using System;

namespace RomanApp.Controller.Offline.States
{
    public abstract class BaseState : RoomState
    {
        public override AlienTicket OnJoined(Passport passport)
        {
            AlienTicket retval = null;

            //retval = new MemberTicket(passport, CreateMember());
            retval = new GateTicket(passport, typeof(LoginGate));

            return retval;
        }

        public override Type OnJoined(IMember member)
        {
            return typeof(BudgetState);
        }

        public override MemberTicket OnJoined(Passport passport, TrespasserId trespasserId)
        {
            MemberTicket retval = null;

            LoginId loginId = (LoginId)trespasserId;

            IMember member = CreateMember();
            member.Locker.Add(RoomHandler.LOCKER_MEMBER_NAME, loginId.Name);
            retval = new MemberTicket(passport, member);

            return retval;
        }

        #region Overriden

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
