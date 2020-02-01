using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class YourContributionOutput : ContributionOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Your.Contribution.Output";

    }
}
