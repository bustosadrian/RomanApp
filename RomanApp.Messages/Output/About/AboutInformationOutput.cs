using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.About
{
    [Serializable]
    [Message(KEY)]
    public class AboutInformationOutput : OutputMessage
    {
        private const string KEY = "RomanApp.About.Output.Information";
    }
}


