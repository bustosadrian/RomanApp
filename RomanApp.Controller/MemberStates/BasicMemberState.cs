using Reedoo.NET.Messages;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Messages;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.MemberStates
{
    public abstract class BasicMemberState : BaseMemberState
    {
        private HelpTopic? _defaultHelpTopic;

        public BasicMemberState()
            : this (null)
        {

        }

        public BasicMemberState(HelpTopic? defaultHelpTopic)
        {
            _defaultHelpTopic = defaultHelpTopic;
        }

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
                Topic = message.Topic ?? _defaultHelpTopic.Value,
            });
        }

        #endregion

    }
}
