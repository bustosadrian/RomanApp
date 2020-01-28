using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class SheetBriefingOutput : BaseEntityOutput
    {
        private const string KEY = "RomanApp.Event.Sheet.Briefing";

        #region Properties

        public string EventName
        {
            get;
            set;
        }

        public List<GuestOutput> Guests
        {
            get;
            set;
        }

        public List<ExpenseOutput> Expenses
        {
            get;
            set;
        }

        #endregion
    }
}
