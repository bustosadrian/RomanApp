using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class ShareGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Share";

        public ShareGroupOutput()
        {

        }


        #region Properties

        public int GuestsCount
        {
            get;
            set;
        }

        public decimal Share
        {
            get;
            set;
        }

        public bool HasPartialDebtors
        {
            get;
            set;
        }

        public bool HasNoDebtors
        {
            get;
            set;
        }

        #endregion
    }
}
