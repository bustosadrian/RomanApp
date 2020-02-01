using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class GuestOutput : ItemOutput
    {
        private const string KEY = "RomanApp.Event.Sheet.Guest.Output";

        #region Properties

        public bool IsSelf
        {
            get;
            set;
        }

        #endregion
    }
}
