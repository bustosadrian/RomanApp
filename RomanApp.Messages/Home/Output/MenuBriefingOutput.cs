using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Home.Output
{
    [Serializable]
    [Message(KEY)]
    public class MenuBriefingOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Home.Menu.Briefing";

        #region Properties

        public bool RemoteAccessEnabled
        {
            get;
            set;
        }

        public string CurrentEventName
        {
            get;
            set;
        }

        #endregion
    }
}
