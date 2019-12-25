using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(Key = KEY)]
    public class GuestOutcomeMessage : OutputMessage
    {
        private const string KEY = "RomanApp.Guest.Outcome";

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        #endregion
    }
}
