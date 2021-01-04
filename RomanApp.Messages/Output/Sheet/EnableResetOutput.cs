using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class EnableResetOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Enable.Reset";

        #region Properties

        public bool ResetEnabled
        {
            get;
            set;
        }

        #endregion
    }
}
