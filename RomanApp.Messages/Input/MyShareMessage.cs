using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(KEY)]
    public class MyShareMessage : InputMessage
    {
        private const string KEY = "RomanApp.My.Share";

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
