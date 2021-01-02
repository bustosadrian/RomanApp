using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ItemsAmountOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Items.Amount";

        #region Properties

        public decimal GuestsAmount
        {
            get;
            set;
        }

        public decimal ExpensesAmount
        {
            get;
            set;
        }

        #endregion
    }
}
