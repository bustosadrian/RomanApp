using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class GuestOutput : BaseEntityOutput
    {
        private const string KEY = "RomanApp.Event.Sheet.Guest";

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public ShareOutput Share
        {
            get;
            set;
        }

        #endregion
    }
}
