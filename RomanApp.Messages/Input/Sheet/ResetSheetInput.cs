using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ResetSheetInput : InputMessage
    {
        private const string KEY = "RomanApp.Sheet.Input.Reset";
    }
}
