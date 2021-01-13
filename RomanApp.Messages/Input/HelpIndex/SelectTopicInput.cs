using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input.HelpIndex
{
    [Serializable]
    [Message(KEY)]
    public class SelectTopicInput : InputMessage
    {
        private const string KEY = "RomanApp.Help.Index.Input.Select.Topic";

        #region Properties

        public HelpTopic Topic
        {
            get;
            set;
        }

        #endregion
    }
}
