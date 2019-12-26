using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(Key = KEY)]
    public class LoginMessage : InputMessage
    {
        private const string KEY = "RomanApp.Login";

        #region Properties

        [Required]
        public string Name
        {
            get;
            set;
        }

        #endregion
    }
}
