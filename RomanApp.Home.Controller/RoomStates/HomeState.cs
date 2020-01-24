using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Home.Controller.MemberStates.Menu;
using System;

namespace RomanApp.Home.Controller.RoomStates
{
    public class HomeState : RoomState
    {
        public override void Brief(IMember member)
        {
            
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
