using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class UpdateOthersContributionInput : UpdateContributionInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Update.Others.Contribution.Input";

    }
}
