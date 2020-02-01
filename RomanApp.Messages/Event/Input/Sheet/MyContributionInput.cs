using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class MyContributionInput : UpdateContributionInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Set.My.Contribution.Input";
        
    }
}
