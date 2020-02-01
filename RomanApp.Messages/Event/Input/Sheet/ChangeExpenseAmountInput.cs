using Reedoo.NET.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ChangeExpenseAmountInput : ChangeItemAmountInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Change.Expense.Amount.Input";
    }
}
