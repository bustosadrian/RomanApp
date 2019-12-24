using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Input
{
    [Serializable]
    [Message(Key = KEY)]
    public class AddGuestMessage : AddItemMessage
    {
        private const string KEY = "RomanApp.Add.Guest";
        
    }
}
