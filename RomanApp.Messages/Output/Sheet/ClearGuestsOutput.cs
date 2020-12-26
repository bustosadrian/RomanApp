using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ClearGuestsOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Clear.Guests";
    }
}

