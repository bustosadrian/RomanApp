using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output.Help;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.HELP)]
    public class HelpMemberState : BaseMemberState
    {
        private HelpTopic _topic;

        public override void OnLoad(object parameters)
        {
            HelpParameters p = (HelpParameters)parameters;
            _topic = p.Topic;
        }

        public override void Brief()
        {
            Queue(new ShowTopicOutput()
            {
                Topic = _topic,
            });
        }

        #region Messages

        [Reader]
        public void Action(BackInput message)
        {
            ChangeState(typeof(SheetMemberState));
        }

        #endregion
    }
}
