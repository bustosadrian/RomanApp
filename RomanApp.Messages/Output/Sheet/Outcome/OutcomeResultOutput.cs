using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet.Outcome
{
    [Serializable]
    [Message(KEY)]
    public class OutcomeResultOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Result";

        #region Properties

        public OutcomeResult Value
        {
            get;
            set;
        }

        #endregion
    }

    public enum OutcomeResult
    {
        NotEnoughGuests = 0,
        NoTotal = 1,
        NoDebtors = 2,
        Ready = 3,
    }
}
