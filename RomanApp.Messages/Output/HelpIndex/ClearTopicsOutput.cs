using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.HelpIndex
{
    [Serializable]
    [Message(KEY)]
    public class ClearTopicsOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Help.Index.Clear.Topics";

    }
}
