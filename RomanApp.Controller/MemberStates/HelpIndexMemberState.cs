using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Messages;
using RomanApp.Messages.Input.HelpIndex;
using RomanApp.Messages.Output.HelpIndex;
using System;
using System.Collections.Generic;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.HELP_INDEX)]
    public class HelpIndexMemberState : BasicMemberState
    {
        private const string LOCKER_PREVIOUS_STATE = "previous_state";

        private const string LOCKER_TOPIC = "previous_topic";

        public override void OnLoad(object parameters)
        {
            HelpIndexParameters p = (HelpIndexParameters)parameters;

            if (p.PreviousState == null)
            {
                throw new ArgumentNullException(nameof(p.PreviousState));
            }

            PreviousState = p.PreviousState.FullName;
            Topic = p.Topic;
        }

        private void BackToHelp(HelpTopic? topic = null)
        {
            ChangeState(typeof(HelpMemberState), new HelpParameters()
            {
                PreviousState = Type.GetType(PreviousState),
                Topic = topic ?? Topic,
            });
        }

        protected override void OnBack()
        {
            BackToHelp();
        }

        private List<HelpTopicOutput> BuildIndex()
        {
            List<HelpTopicOutput> retval = null;

            retval = new List<HelpTopicOutput>
            {
                new HelpTopicOutput(HelpTopic.Overview),
                new HelpTopicOutput(HelpTopic.SheetOverview)
                {
                    SubTopics =
                {
                    new HelpTopicOutput(HelpTopic.SheetInputOverview),
                    new HelpTopicOutput(HelpTopic.SheetOutcomeOverview),
                }
                },
                new HelpTopicOutput(HelpTopic.Settings)
            };

            return retval;
        }

        public override void Brief()
        {
            Queue(new ClearTopicsOutput());
            foreach(var o in BuildIndex())
            {
                Queue(o);
            }
        }

        #region Messages

        [Reader]
        public void Read(SelectTopicInput message)
        {
            BackToHelp(message.Topic);
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
