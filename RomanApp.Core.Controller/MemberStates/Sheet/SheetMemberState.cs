using Reedoo.NET.Controller;
using RomanApp.Messages.Event.Output;

namespace RomanApp.Core.Controller.MemberStates.Sheet
{

    [ApplicationState(KEY)]
    public class SheetMemberState : EventMemberState
    {
        private const string KEY = "RomanApp.Event.Sheet";

        public override void Brief()
        {
            SheetBriefingOutput briefing = new SheetBriefingOutput()
            {
                EventName = CurrentEvent.Name,
            };
            Queue(briefing);
        }

        protected override void OnBack()
        {
            RomanAppRoomState.OnExit(Member);
        }
    }
}
