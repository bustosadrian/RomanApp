using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(KEY)]
    public class GuestMessage : ItemMessage
    {
        private const string KEY = "RomanApp.Guest";
    }
}
