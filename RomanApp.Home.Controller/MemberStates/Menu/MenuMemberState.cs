using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Home.Controller.MemberStates.Create;
using RomanApp.Home.Controller.MemberStates.Help;
using RomanApp.Messages.Home.Input;
using RomanApp.Messages.Home.Output;

namespace RomanApp.Home.Controller.MemberStates.Menu
{
    [ApplicationState(KEY)]
    public class MenuMemberState : HomeMemberState
    {
        private const string KEY = "RomanApp.Home.Menu";

        public override void Brief()
        {
            MenuBriefingOutput briefing = new MenuBriefingOutput()
            {
                RemoteAccessEnabled = false,
            };
            if(CurrentEvent != null)
            {
                briefing.CurrentEventName = CurrentEvent.Name;
            }
            Queue(briefing);
        }

        #region Messages

        [Reader]
        public void Read(CreateEventInput message)
        {
            ChangeState(typeof(CreateMemberState));
        }

        [Reader]
        public void Read(ResumeEventInput message)
        {

        }

        [Reader]
        public void Read(JoinEventInput message)
        {

        }

        [Reader]
        public void Read(HelpInput message)
        {
            ChangeState(typeof(HelpMemberState));
        }

        #endregion
    }
}
