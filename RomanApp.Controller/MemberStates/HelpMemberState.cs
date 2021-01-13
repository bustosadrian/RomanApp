using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Controller.Utils;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Help;
using RomanApp.Messages.Output.Help;
using System;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.HELP)]
    public class HelpMemberState : BasicMemberState
    {
        private const string LOCKER_PREVIOUS_STATE = "previous_state";

        private const string LOCKER_TOPIC = "previous_topic";

        public override void OnLoad(object parameters)
        {
            HelpParameters p = (HelpParameters)parameters;

            if (p.PreviousState == null)
            {
                throw new ArgumentNullException(nameof(p.PreviousState));
            }


            PreviousState = p.PreviousState.FullName;
            Topic = p.Topic;
        }

        public override void Brief()
        {
            QueueShowTopic();
        }

        protected override void OnBack()
        {
            Type type = Type.GetType(PreviousState);
            ChangeState(type);
        }

        #region Queues

        private void QueueShowTopic()
        {
            Queue(new ShowTopicOutput()
            {
                Topic = Topic,
                RelatedTopics = HelpTopicRelations.GetRelatedTopics(Topic).ToArray(),
            });
        }

        #endregion


        #region Messages

        [Reader]
        public void Action(GoToHelpIndexInput message)
        {
            ChangeState(typeof(HelpIndexMemberState), new HelpIndexParameters()
            {
                PreviousState = Type.GetType(PreviousState),
                Topic = Topic,
            });
        }

        [Reader]
        public void Action(SeeAlsoInput message)
        {
            Topic = message.Topic;
            QueueShowTopic();
        }

        [Reader]
        public override void Action(GetHelpInput message)
        {
            
        }

        #endregion

        #region Locker

        private string PreviousState
        {
            get
            {
                return Locker.Get<string>(LOCKER_PREVIOUS_STATE);
            }
            set
            {
                Locker.Add(LOCKER_PREVIOUS_STATE, value);
            }
        }

        private HelpTopic Topic
        {
            get
            {
                return Locker.Get<HelpTopic>(LOCKER_TOPIC);
            }
            set
            {
                Locker.Add(LOCKER_TOPIC, value);
            }
        }

        #endregion
    }
}
