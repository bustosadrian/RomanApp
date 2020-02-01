using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ExpenseOutput : ItemOutput
    {
        private const string KEY = "RomanApp.Event.Sheet.Expense.Output";
    }
}
