using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Help
{
    [Serializable]
    [Message(KEY)]
    public class ShowTopicOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Help.Output.Show.Topic";

        #region Properties

        public HelpTopic Topic
        {
            get;
            set;
        }

        public HelpTopic[] RelatedTopics
        {
            get;
            set;
        }

        #endregion
    }
}
