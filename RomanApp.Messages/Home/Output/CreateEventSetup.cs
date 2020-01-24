using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Home.Output
{
    [Serializable]
    [Message(KEY)]
    public class CreateEventSetup : OutputMessage
    {
        private const string KEY = "RomanApp.Home.Create.Event.Setup";

        #region Properties

        public bool IsAccessEnabled
        {
            get;
            set;
        }

        #endregion
    }
}
