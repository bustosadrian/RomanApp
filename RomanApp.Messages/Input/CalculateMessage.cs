using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(Key = KEY)]
    public class CalculateMessage : InputMessage
    {
        private const string KEY = "RomanApp.Calculate";
    }
}
