using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Core.Controller;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.Gates.Login;
using RomanApp.Home.Controller.MemberStates.Menu;
using System;

namespace RomanApp.Home.Controller.RoomStates
{
    public class HomeState : RomanAppRoomState, IRomanAppRoomState
    {
        public override void Brief(IMember member)
        {
            
        }

        public void OnExit(IMember member)
        {
            ChangeMemberState(member, typeof(MenuMemberState));
        }

        private GateTicket WriteAlienTicket(Passport passport)
        {
            GateTicket retval = null;

            retval = new GateTicket(passport, typeof(LoginGate));

            return retval;
        }

        public override AlienTicket OnJoined(Passport passport)
        {
            MemberTicket retval = null;

            IMember member = CreateMember(passport);
            retval = new MemberTicket(passport, member);

            return retval;
        }

        //public override AlienTicket OnJoined(Passport passport)
        //{
        //    return WriteAlienTicket(passport);
        //}

        public override MemberTicket OnJoined(Passport passport, TrespasserId trespasserId)
        {
            MemberTicket retval = null;

            LoginId loginId = (LoginId)trespasserId;

            Guest guest = EventService.AddGuest(CurrentEvent, loginId.Name, 0, null);

            IMember member = CreateMember(passport);
            member.Locker.Add(RomanAppRoomHandler.LOCKER_MEMBER_GUEST, guest);
            retval = new MemberTicket(passport, member);


            return retval;
        }

        public override Type OnJoined(IMember member)
        {
            return typeof(MenuMemberState);
        }
    }
}
