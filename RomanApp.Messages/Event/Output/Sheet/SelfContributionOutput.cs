using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class SelfContributionOutput : ContributionOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Self.Contribution.Output";

    }
}
