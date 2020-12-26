using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(KEY)]
    public class BackInput : InputMessage
    {
        private const string KEY = "RomanApp.Input.Back";
    }
}
