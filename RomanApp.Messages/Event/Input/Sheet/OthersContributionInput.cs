using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class OthersContributionInput : UpdateContributionInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Set.Others.Contribution.Input";

    }
}
