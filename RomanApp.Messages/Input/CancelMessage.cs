using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(KEY)]
    public class CancelMessage : InputMessage
    {
        private const string KEY = "RomanApp.Cancel";
    }
}
