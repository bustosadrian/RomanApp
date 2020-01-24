using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Home.Output
{
    [Serializable]
    [Message(KEY)]
    public class CreateEventBriefingOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Home.Create.Event.Briefing";

        #region Properties

        public bool IsAccessEnabled
        {
            get;
            set;
        }

        #endregion
    }
}
