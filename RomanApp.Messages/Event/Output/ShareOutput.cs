using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output
{

    [Serializable]
    [Message(KEY)]
    public class ShareOutput : BaseEntityOutput
    {
        private const string KEY = "RomanApp.Event.Share";

        #region Properties

        public decimal Amount
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        #endregion
    }
}
