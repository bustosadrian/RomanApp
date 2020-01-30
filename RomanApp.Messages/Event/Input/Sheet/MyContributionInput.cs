using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class MyContributionInput : InputMessage
    {
        private const string KEY = "RomanApp.Event.Sheet.Set.Contribution";

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
