using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ChangeMyContributionInput : AddItemInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Change.My.Contribution";

    }
}
