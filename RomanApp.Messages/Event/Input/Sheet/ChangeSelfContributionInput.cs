using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ChangeSelfContributionInput : ChangeContributionInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Change.Self.Contribution.Input";

    }
}
