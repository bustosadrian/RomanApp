using Reedoo.NET.Messages;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Messages;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.MemberStates
{
    public abstract class BasicMemberState : BaseMemberState
    {

        protected virtual void OnBack()
        {

        }

        #region Messages

        [Reader]
        public virtual void Action(BackInput message)
        {
            OnBack();
        }

        [Reader]
        public virtual void Action(GetHelpInput message)
        {
            ChangeState(typeof(HelpMemberState), new HelpParameters()
            {
                PreviousState = GetType(),
                Topic = message.Topic ?? HelpTopic.Overview,
            });
        }

        #endregion

    }
}
