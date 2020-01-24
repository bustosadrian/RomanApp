using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(KEY)]
    public class ProfileMessage : OutputMessage
    {
        private const string KEY = "RomanApp.Profile";

        #region Properties

        public string Name
        {
            get;
            set;
        }

        #endregion
    }
}
