using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(KEY)]
    public class GoToAboutInput : InputMessage
    {
        private const string KEY = "RomanApp.Input.Go.To.About";

        #region Properties

        #endregion
    }
}
