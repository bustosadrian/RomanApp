using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ChangeOthersContributionInput : ChangeItemAmountInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Change.Others.Contribution";
    }
}
