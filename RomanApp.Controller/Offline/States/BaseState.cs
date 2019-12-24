using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
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

            retval = new BudgetMemberState();

            return retval;
        }

    }
}
