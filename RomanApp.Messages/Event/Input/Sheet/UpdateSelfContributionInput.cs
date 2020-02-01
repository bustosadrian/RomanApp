using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class UpdateSelfContributionInput : UpdateContributionInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Update.Self.Contribution.Input";
        
    }
}
