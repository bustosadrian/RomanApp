using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output
{
    [Serializable]
    [Message(KEY)]
    public class SheetBriefingOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Event.Sheet.Briefing";

        #region Properties

        public string EventName
        {
            get;
            set;
        }

        #endregion
    }
}
