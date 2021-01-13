using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input.Help
{
    [Serializable]
    [Message(KEY)]
    public class SeeAlsoInput : InputMessage
    {
        private const string KEY = "RomanApp.Help.Input.See.Also";

        #region Properties

        public HelpTopic Topic
        {
            get;
            set;
        }

        #endregion
    }
}
