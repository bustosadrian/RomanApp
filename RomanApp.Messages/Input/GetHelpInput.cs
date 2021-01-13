using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(KEY)]
    public class GetHelpInput : InputMessage
    {
        private const string KEY = "RomanApp.Input.Get.Help";

        #region Properties

        public HelpTopic? Topic
        {
            get;
            set;
        }

        #endregion
    }
}
