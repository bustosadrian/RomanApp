using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ItemsCountOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Total.Items";

        #region Properties
        
        public int GuestsCounts
        {
            get;
            set;
        }

        public int ExpensesCount
        {
            get;
            set;
        }

        #endregion
    }
}
