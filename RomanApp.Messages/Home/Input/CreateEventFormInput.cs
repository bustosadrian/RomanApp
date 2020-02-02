using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Home.Input
{
    [Serializable]
    [Message(KEY)]
    public class CreateEventFormInput : InputMessage
    {
        private const string KEY = "RomanApp.Home.Create.Event.Form";

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public EventAccess EventAccess
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsUseRoundFigures
        {
            get;
            set;
        }

        #endregion
    }
}
