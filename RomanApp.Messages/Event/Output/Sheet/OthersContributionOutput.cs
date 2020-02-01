using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class OthersContributionOutput : ContributionOutput
    {
        private const string KEY = "RomanApp.Event.Sheet.Others.Contribution.Output";

        #region Properties

        public string GuestName
        {
            get;
            set;
        }

        public bool IsSelf
        {
            get;
            set;
        }

        #endregion
    }
}
