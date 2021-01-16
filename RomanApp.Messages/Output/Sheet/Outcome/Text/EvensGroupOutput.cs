using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class EvensGroupOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Text.Group.Evens";

        #region Properties

        public List<string> Evens
        {
            get;
            set;
        }

        #endregion
    }
}