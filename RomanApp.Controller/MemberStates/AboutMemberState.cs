using Reedoo.NET.Controller;
using RomanApp.Commons;
using RomanApp.Messages.Output.About;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.ABOUT)]
    public class AboutMemberState : BasicMemberState
    {
        public override void Brief()
        {
            Queue(new AboutInformationOutput());
        }

        protected override void OnBack()
        {
            ChangeState(typeof(SheetMemberState));
        }
    }
}
