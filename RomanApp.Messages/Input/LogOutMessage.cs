using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(Key = KEY)]
    public class LogOutMessage : InputMessage
    {
        private const string KEY = "RomanApp.Log.Out";
    }
}
