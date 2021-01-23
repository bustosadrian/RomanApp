using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class UseNumericKeyboardOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Use.Numeric";

        #region Properties

        public bool UseNumericKeyboard
        {
            get;
            set;
        }

        #endregion
    }
}
