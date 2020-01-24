using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Home.Input
{
    [Serializable]
    [Message(KEY)]
    public class JoinEventInput : InputMessage
    {
        private const string KEY = "RomanApp.Home.Join.Event";
    }
}
