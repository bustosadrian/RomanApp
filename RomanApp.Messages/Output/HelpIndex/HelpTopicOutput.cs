using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.HelpIndex
{
    [Serializable]
    [Message(KEY)]
    public class HelpTopicOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Help.Index.Output.Help.Topic";

        public HelpTopicOutput()
        {
            SubTopics = new List<HelpTopicOutput>();
        }

        public HelpTopicOutput(HelpTopic topic)
            : this ()
        {
            Topic = topic;
        }

        #region Properties

        public HelpTopic Topic
        {
            get;
            set;
        }

        public List<HelpTopicOutput> SubTopics
        {
            get;
            set;
        }

        #endregion

    }
}
