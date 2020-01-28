using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class RemoveGuestOutput : RemoveItemOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Remove.Guest.Output";
        
    }
}
