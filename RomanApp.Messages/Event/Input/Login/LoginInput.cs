using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Event.Input.Login
{
    [Serializable]
    [Message(KEY)]
    public class LoginInput : InputMessage
    {
        private const string KEY = "RomanApp.Event.Login.Login";

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
