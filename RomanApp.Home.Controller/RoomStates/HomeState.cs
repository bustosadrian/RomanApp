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

        public override Type OnJoined(IMember member)
        {
            return typeof(MenuMemberState);
        }
    }
}
