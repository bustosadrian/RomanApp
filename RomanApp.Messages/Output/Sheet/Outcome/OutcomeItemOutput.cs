using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet.Outcome
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeItemOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Item";

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
