using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class AddGuestInput : AddItemInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Add.Guest";
        
    }
}
