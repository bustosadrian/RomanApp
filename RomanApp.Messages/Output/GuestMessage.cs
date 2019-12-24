using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(Key = KEY)]
    public class GuestMessage : OutputMessage
    {
        private const string KEY = "RomanApp.Guest";
    }
}
