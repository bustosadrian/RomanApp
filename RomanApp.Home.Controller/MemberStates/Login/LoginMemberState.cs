using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Core.Controller;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.MemberStates.Sheet;
using RomanApp.Home.Controller.MemberStates.Menu;
using RomanApp.Messages.Event.Input.Login;

namespace RomanApp.Home.Controller.MemberStates.Login
{
    [ApplicationState(KEY)]
    public class LoginMemberState : HomeMemberState
    {
        private const string KEY = "RomanApp.Event.Login";

        public override void Brief()
        {
            
        }

        protected override void OnBack()
        {
            ChangeState(typeof(MenuMemberState));
        }

        private void Login(LoginInput message) 
        {
            Guest guest = EventService.AddGuest(CurrentEvent, message.Name, 0, null);
            Member.Locker.Add(RomanAppRoomHandler.LOCKER_MEMBER_GUEST, guest);
            ChangeState(typeof(SheetMemberState));
        }

        #region Messages

        [Reader]
        public void Read(LoginInput message)
        {
            Login(message);
        }

        #endregion
    }
}
